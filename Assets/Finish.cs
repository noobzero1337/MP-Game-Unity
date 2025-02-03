using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public VolumeController volumeController; // Referensi ke VolumeController
    public AudioClip finishSound; // Suara yang akan diputar saat finish
    
    void Start()
    {
        // Pastikan volumeController di-assign di inspector atau diambil dari scene
        if (volumeController == null)
        {
            volumeController = FindObjectOfType<VolumeController>();
        }
        
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            PlayFinishSound();
            CompleteLevel();
        }

    }


    private void PlayFinishSound()
    {
        if (volumeController != null && finishSound != null)
        {
            volumeController.audioSource.PlayOneShot(finishSound);
        }
    }
    

    private void CompleteLevel()
    {
        // Reset health ke 5
        PlayerPrefs.SetInt("Health", 5); // Simpan nilai health awal ke PlayerPrefs
        PlayerPrefs.Save();
        // Pindah ke level berikutnya
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
