using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerLifes : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;
    private PlayerHealth playerHealth;

    public VolumeController volumeController; // Referensi ke VolumeController
    public AudioClip trapSound; // Suara yang akan diputar saat terkena trap

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerHealth = GetComponent<PlayerHealth>();

        if (volumeController == null)
        {
            volumeController = FindObjectOfType<VolumeController>();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            PlayTrapSound();
            Die();
        }
    }

    private void PlayTrapSound()
    {
        if (volumeController != null && trapSound != null)
        {
            volumeController.audioSource.PlayOneShot(trapSound);
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
