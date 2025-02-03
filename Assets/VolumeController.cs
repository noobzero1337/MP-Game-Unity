using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{

    public Slider volumeSlider; // Slider untuk mengatur volume
    public AudioSource audioSource; // AudioSource yang akan diatur volumenya

    // Nama kunci untuk menyimpan volume di PlayerPrefs
    private const string VolumePrefKey = "VolumeValue";

    void Start()
    {
        // Memuat nilai volume dari PlayerPrefs, jika tidak ada nilai, gunakan volume default dari AudioSource
        float savedVolume = PlayerPrefs.GetFloat(VolumePrefKey, audioSource.volume);

        // Mengatur volume AudioSource dan nilai awal slider
        audioSource.volume = savedVolume;
        volumeSlider.value = savedVolume;

        // Menambahkan listener pada slider untuk memanggil metode OnVolumeChange setiap kali nilai slider berubah
        volumeSlider.onValueChanged.AddListener(delegate { OnVolumeChange(); });
    }

    void OnVolumeChange()
    {
        // Memperbarui volume AudioSource berdasarkan nilai slider
        audioSource.volume = volumeSlider.value;

        // Menyimpan nilai volume ke PlayerPrefs
        PlayerPrefs.SetFloat(VolumePrefKey, audioSource.volume);
    }
}
