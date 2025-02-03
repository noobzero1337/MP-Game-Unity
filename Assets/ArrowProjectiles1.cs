using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowProjectiles1 : MonoBehaviour
{
    public float speed = 10f; // Kecepatan panah
    public float maxDistance = 10f; // Jarak maksimum yang dapat ditempuh panah
    private Vector3 initialPosition; // Posisi awal panah
    private Quaternion initialRotation; // Rotasi awal panah

    void Start()
    {
        // Simpan rotasi awal panah
        initialRotation = transform.rotation;
    }

    void Update()
    {
        // Mendapatkan vektor arah berdasarkan rotasi awal panah
        Vector3 direction = initialRotation * Vector3.up;

        // Bergerak ke arah yang sudah dirotasi dengan mempertahankan posisi Y dan Z
        transform.Translate(direction * speed * Time.deltaTime);

        // Periksa jika jarak yang ditempuh lebih dari maxDistance
        if (Vector3.Distance(initialPosition, transform.position) >= maxDistance)
        {
            // Nonaktifkan atau hapus panah jika jarak lebih dari maxDistance
            gameObject.SetActive(false); // Nonaktifkan panah (jika menggunakan setActive)
            // Destroy(gameObject); // Hapus panah objek dari scene
        }
    }

    // Method ini digunakan untuk mengembalikan panah ke posisi awal
    public void ResetArrow()
    {
        transform.position = initialPosition;
        transform.rotation = initialRotation;
    }

    // Method untuk menetapkan posisi awal
    public void SetInitialPosition(Vector3 position)
    {
        initialPosition = position;
    }
   
}
