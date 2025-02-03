using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenController : MonoBehaviour
{
    public float splashScreenDuration = 2f; // Durasi tampilan splash screen (dalam detik)

    void Start()
    {
        // Mulai coroutine untuk menampilkan splash screen
        StartCoroutine(ShowSplashScreen());
    }

    IEnumerator ShowSplashScreen()
    {
        // Tunggu selama durasi tampilan splash screen
        yield return new WaitForSeconds(splashScreenDuration);

        // Pindah ke scene berikutnya dalam urutan build index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
