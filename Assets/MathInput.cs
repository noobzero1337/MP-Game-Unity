using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class MathInput : MonoBehaviour
{
    public TMP_InputField answerInputField; // Input field untuk jawaban
    public Button submitButton; // Button untuk submit jawaban
    public GameObject nextLevelObject; // Game object untuk kondisi "Next Level"
    public GameObject currentObject; // Game object untuk level saat ini
    
    public int correctAnswer; // Untuk memasukkan jawaban yang benar

    // Dipanggil saat button ditekan
    public void SubmitAnswer()
    {

    // Mendapatkan jawaban dari input field
        string inputText = answerInputField.text.Trim(); // Menghapus spasi di awal dan akhir input
        if (string.IsNullOrEmpty(inputText))
        {
            // Jika input kosong, hentikan eksekusi
            return;
        }
    
    // Menyembunyikan kedua game object secara instan
    nextLevelObject.SetActive(false);

    // Mendapatkan jawaban dari input field
    int answer;
    bool isNumber = int.TryParse(answerInputField.text, out answer);

    // Memeriksa apakah yang dimasukkan adalah angka dan jawabannya benar
    if (isNumber && answer == correctAnswer)
    {
        // Menampilkan game object untuk kondisi "Next Level" jika jawaban benar
        nextLevelObject.SetActive(true);
        currentObject.SetActive(false);
    }
    else
    {
        // Lanjut ke scene berikutnya "Game Over' jika menjawab pertanyaan secara salah
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        currentObject.SetActive(false);
    }

}

}
