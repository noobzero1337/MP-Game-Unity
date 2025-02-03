using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MathDropdown : MonoBehaviour
{
    public TMP_Dropdown answerDropdown; // Dropdown untuk pilihan jawaban
    public Button submitButton; // Button untuk submit jawaban
    public GameObject nextLevelObject; // Game object untuk kondisi "Next Level"
    public GameObject gameOverObject; // Game object untuk kondisi "Game Over"
    public int correctAnswerIndex = -34; // Index pilihan jawaban yang benar

    private bool canInteract = false; // Flag untuk menentukan apakah dapat berinteraksi dengan dropdown

    // Dipanggil saat button "answer" ditekan
    public void EnableInteractivity()
    {
        // Mengaktifkan interaksi dengan dropdown dan tombol submit
        answerDropdown.interactable = true;
        submitButton.gameObject.SetActive(true);

        // Mengatur flag agar dapat berinteraksi
        canInteract = true;
    }

    // Dipanggil saat button "submit" ditekan
    public void SubmitAnswer()
    {
        // Memeriksa apakah dapat berinteraksi
        if (canInteract)
        {
            // Mendapatkan index pilihan yang dipilih dari dropdown
            int selectedAnswerIndex = answerDropdown.value;

            // Memeriksa apakah pilihan yang dipilih adalah jawaban yang benar
            if (selectedAnswerIndex == correctAnswerIndex)
            {
                // Menampilkan game object untuk kondisi "Next Level" dan menyembunyikan game object untuk "Game Over"
                nextLevelObject.SetActive(true);
                gameOverObject.SetActive(false);
            }
            else
            {
                // Menampilkan game object untuk kondisi "Game Over" dan menyembunyikan game object untuk "Next Level"
                nextLevelObject.SetActive(false);
                gameOverObject.SetActive(true);
            }

        }
    }
}
