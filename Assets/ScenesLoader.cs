using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ScenesLoader : MonoBehaviour 
{
    public TMP_Text healthText;
    public int maxHealth = 5;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth; // Atur currentHealth ke maxHealth saat memulai
        UpdateHealthText(); // Perbarui tampilan teks kesehatan
    }

    void UpdateHealthText()
    {
        healthText.text = "Health: " + currentHealth.ToString();  // Memperbarui teks kesehatan
    }


    public void PlayMath ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayParkour ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
    }

    public void WrongAnswer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayMathAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void PlayMathAgain2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    public void BackToMenuMathLose()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    public void BackToMenuWin()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }
    
    public void BackToMainMenu1 ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void BackToMainMenu2()
    {
        PlayerPrefs.SetInt("Health", currentHealth);
        PlayerPrefs.Save();// Mengambil health dari PlayerPrefs

        Debug.Log("Health reset to 5");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
    }

    public void BackToMainMenu3()
    {
        PlayerPrefs.SetInt("Health", currentHealth);
        PlayerPrefs.Save();// Mengambil health dari PlayerPrefs

        Debug.Log("Health reset to 5");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 5);
    }

    public void BackToMainMenu4()
    {
        PlayerPrefs.SetInt("Health", currentHealth);
        PlayerPrefs.Save();// Mengambil health dari PlayerPrefs

        Debug.Log("Health reset to 5");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 6);
    }

    public void BackToMainMenu5()
    {
        PlayerPrefs.SetInt("Health", currentHealth);
        PlayerPrefs.Save();// Mengambil health dari PlayerPrefs

        Debug.Log("Health reset to 5");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 7);
    }

    public void BackToMainMenu6()
    {
        PlayerPrefs.SetInt("Health", currentHealth);
        PlayerPrefs.Save();// Mengambil health dari PlayerPrefs

        Debug.Log("Health reset to 5");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 8);
    }

    public void BackToMainMenu7()
    {
        PlayerPrefs.SetInt("Health", currentHealth);
        PlayerPrefs.Save();// Mengambil health dari PlayerPrefs

        Debug.Log("Health reset to 5");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 9);
    }

    public void BackToMainMenu8()
    {
        PlayerPrefs.SetInt("Health", currentHealth);
        PlayerPrefs.Save();// Mengambil health dari PlayerPrefs

        Debug.Log("Health reset to 5");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 10);
    }

    public void BackToMainMenu9()
    {
        PlayerPrefs.SetInt("Health", currentHealth);
        PlayerPrefs.Save();// Mengambil health dari PlayerPrefs

        Debug.Log("Health reset to 5");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 11);
    }

    public void FinishedParkour()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 12);
    }

    public void PlayAgainParkour()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 10);
    }

    public void ParkourLose()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 13);
    }

    public void PlayAgainParkour1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 9);
    }

    public void Quit()
    {
        Debug.Log("QUITTING GAME");
        Application.Quit();
    }
}
