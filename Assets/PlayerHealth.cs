using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro; // Menambahkan penggunaan namespace
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;  // Nilai maksimum kesehatan pemain
    private int currentHealth;  // Kesehatan saat ini
    public TMP_Text healthText; // Referensi teks untuk menampilkan kesehatan
    public int currentLevel = 1;
    private bool isInvincible = false; // Penanda invincibility
    public float invincibilityDuration = 1.0f;
    private Rigidbody2D rb;
    private Animator anim;
    private int[] levelOffsets = { 9, 8, 7, 6, 5, 4, 3, 2 };

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        currentHealth = PlayerPrefs.GetInt("Health", maxHealth);
        UpdateHealthText(); // Perbarui tampilan teks kesehatan
    }
    
    // Metode untuk mengurangi kesehatan pemain
    public void TakeDamage(int damageAmount)
    {
        if (isInvincible) return; // Jika sedang invincible, keluar dari metode

        currentHealth -= damageAmount;  // Mengurangi kesehatan berdasarkan jumlah damage
        UpdateHealthText();  // Memperbarui tampilan teks kesehatan

        // Simpan currentHealth ke PlayerPrefs
        PlayerPrefs.SetInt("Health", currentHealth);
        PlayerPrefs.Save();

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        if (currentHealth == 0)
        {
            Debug.Log("Player health is 0. Next hit will cause death.");
        }
        else
        {
            StartCoroutine(InvincibilityCoroutine()); // Memulai invincibility
        }
    }

    // Fungsi untuk memperbarui teks kesehatan pada layar
    void UpdateHealthText()
    {
        healthText.text = "Health: " + currentHealth.ToString();  // Memperbarui teks kesehatan
    }

    // Aksi yang dilakukan saat pemain mati
    void Die()
    {
        Debug.Log("Player has died!");

        // Alihkan ke scene selanjutnya
        SwitchScene();
    }

    // Metode untuk beralih ke scene berikutnya
    void SwitchScene()
    {
            if (currentLevel > 0 && currentLevel <= levelOffsets.Length)
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + levelOffsets[currentLevel - 1];
            Debug.Log("Switching to scene index: " + nextSceneIndex);

            // Reset health to maxHealth before switching scenes
            PlayerPrefs.SetInt("Health", maxHealth);
            PlayerPrefs.Save();

            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogError("Invalid level index: " + currentLevel);
        }
    }

    private IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibilityDuration);
        isInvincible = false;
    }

        // Metode untuk mengurangi kesehatan saat bertabrakan dengan objek yang memiliki tag "Trap"
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            if (currentHealth > 0)
            {
                TakeDamage(1); // Mengurangi kesehatan jika bertabrakan dengan tag "Trap"
            }
            else if (currentHealth <= 0)
            {
                // Aksi jika kesehatan sudah habis dan terkena tag "Trap" lagi
                Debug.Log("Player is already dead and hit a trap again!");
                Die();
            }
        }
    }

    // Metode untuk menyimpan nilai maxHealth saat aplikasi keluar atau objek non-aktif
    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Health", maxHealth);  // Menyimpan nilai maxHealth ke PlayerPrefs
        PlayerPrefs.Save();  // Simpan perubahan PlayerPrefs
    }
}
