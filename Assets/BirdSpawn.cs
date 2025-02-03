using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawn : MonoBehaviour
{
    public Transform startPoint; // Titik awal
    public Transform endPoint; // Titik akhir
    public float speed = 5f; // Kecepatan burung

    private Vector3 direction; // Arah gerakan burung
    private Vector3 nextPosition; // Posisi selanjutnya

    void Start()
    {
        // Set posisi awal
        transform.position = startPoint.position;
        // Mengatur arah gerakan burung menuju titik akhir
        direction = (endPoint.position - startPoint.position).normalized;
        // Set posisi pertama
        nextPosition = endPoint.position;
    }

    void Update()
    {
        // Bergerak menuju nextPosition
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed * Time.deltaTime);

        // Jika burung mencapai nextPosition, beri posisi selanjutnya
        if (Vector3.Distance(transform.position, nextPosition) < 0.01f)
        {
            SetNextPosition();
        }
    }

    // Fungsi untuk menetapkan posisi selanjutnya
    void SetNextPosition()
    {
        // Jika burung berada di titik akhir, kembalikan ke titik awal
        if (transform.position == endPoint.position)
        {
            nextPosition = startPoint.position;
        }
        // Jika burung berada di titik awal, bergerak ke titik akhir
        else if (transform.position == startPoint.position)
        {
            nextPosition = endPoint.position;
        }
    }

   // Fungsi untuk memeriksa apakah burung telah mencapai titik akhir
    bool HasReachedEndPoint()
    {
        // Memeriksa apakah burung telah melewati titik akhir
        if (Vector3.Distance(transform.position, endPoint.position) < 0.1f)
        {
            return true;
        }
        return false;
    }

    // Fungsi untuk me-reset posisi burung ke titik awal
    void ResetToStartPoint()
    {
        transform.position = startPoint.position;
    }
}
