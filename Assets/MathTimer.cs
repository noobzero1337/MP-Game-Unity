using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MathTimer : MonoBehaviour
{
    public float totalTime = 40f; // Waktu total timer dalam detik
    public TMP_Text timerText; // UI Text untuk menampilkan timer
    public GameObject currentObject; // Game object untuk level saat ini

    private float timeRemaining; // Waktu tersisa
    private bool gameRunning = true; // Status permainan (berjalan atau tidak)

    void Start()
    {
        timeRemaining = totalTime;
        StartCoroutine(UpdateTimer());
    }

    IEnumerator UpdateTimer()
    {
        while (gameRunning && timeRemaining > 0)
        {
            yield return new WaitForSeconds(1f); // Tunggu satu detik

            if (gameRunning)
            {
                timeRemaining -= 1f; // Kurangi waktu tersisa jika permainan sedang berjalan
                UpdateTimerDisplay();

                if (timeRemaining <= 0)
                {
                    // Jika waktu habis, tampilkan scene game over
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
        }
    }

    void UpdateTimerDisplay()
    {
        // Konversi waktu tersisa menjadi format menit:detik
        int minutes = Mathf.FloorToInt(timeRemaining / 60f);
        int seconds = Mathf.FloorToInt(timeRemaining % 60f);
        string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);

        // Perbarui teks pada UI Text
        timerText.text = "Time: " + timerString;
    }

    public void RestartTimer()
    {
        // Reset timer ke nilai awal (40 detik)
        timeRemaining = totalTime;
        gameRunning = true;
        UpdateTimerDisplay(); // Perbarui tampilan timer
    }
}
