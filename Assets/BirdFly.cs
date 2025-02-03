using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFly : MonoBehaviour
{
    public Transform startPoint; // Titik awal
    public Transform endPoint; // Titik akhir
    public float speed = 20f; // Kecepatan burung

    private Vector3 nextPosition; // Posisi selanjutnya

    void Start()
    {
        // Set posisi awal
        transform.position = startPoint.position;
        // Set posisi pertama
        nextPosition = endPoint.position;
    }

    void Update()
    {
        // Bergerak menuju nextPosition
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed * Time.deltaTime);

        // Flipping burung jika bergerak ke arah kanan
        if (nextPosition == endPoint.position)
        {
            transform.localScale = new Vector3(1f, 1f, 1f); // Flip horizontal
        }
        // Flipping burung jika bergerak ke arah kiri
        else if (nextPosition == startPoint.position)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f); // Kembalikan ke skala awal
        }

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
}
