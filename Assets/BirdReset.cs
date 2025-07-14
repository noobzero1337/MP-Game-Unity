using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdReset : MonoBehaviour
{
   public Transform startPoint; // Titik awal

    void OnTriggerEnter2D(Collider2D other)
    {
        // Cek jika yang bersentuhan adalah burung
        if (other.CompareTag("Bird"))
        {
            // Reset posisi burung ke titik awal
            other.transform.position = startPoint.position;
        }
    }
}
