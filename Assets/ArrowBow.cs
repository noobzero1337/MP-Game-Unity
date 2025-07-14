using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBow : MonoBehaviour
{

    public GameObject arrowPrefab; // Prefab panah
    public Transform arrowSpawnPoint; // Titik spawn panah
    public float spawnDelay = 2f; // Interval waktu munculnya panah
    public float maxArrowDistance = 20f; // Jarak maksimum panah

    private List<GameObject> arrows = new List<GameObject>(); // List untuk menyimpan referensi panah

    void Start()
    {
        // Memanggil fungsi untuk munculkan panah setiap 2 detik
        InvokeRepeating("SpawnArrow", 0f, spawnDelay);
    }

    void SpawnArrow()
    {
                // Mencari panah yang tidak aktif untuk digunakan kembali
        GameObject newArrow = GetInactiveArrow();
        
        if (newArrow == null)
        {
            // Membuat panah baru jika tidak ada panah yang tidak aktif
            newArrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, arrowSpawnPoint.rotation);
            arrows.Add(newArrow);
        }
        else
        {
            // Mengaktifkan kembali panah yang tidak aktif
            newArrow.transform.position = arrowSpawnPoint.position;
            newArrow.transform.rotation = arrowSpawnPoint.rotation;
            newArrow.SetActive(true);
        }

        // Set initial position and max distance for the arrow
        ArrowProjectiles arrowScript = newArrow.GetComponent<ArrowProjectiles>();
        if (arrowScript != null)
        {
            arrowScript.SetInitialPosition(arrowSpawnPoint.position);
            arrowScript.maxDistance = maxArrowDistance;
        }

        newArrow.transform.Rotate(0f, 0f, -45.709f);
    }

    // Method untuk mencari panah yang tidak aktif
    GameObject GetInactiveArrow()
    {
        foreach (GameObject arrow in arrows)
        {
            if (!arrow.activeInHierarchy)
            {
                return arrow;
            }
        }
        return null;
    }
}
