using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissapearArrow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

     private void OnCollisionEnter2D(Collision2D collision)
     {
         if (collision.gameObject.CompareTag("Trap"))
         {
            // Nonaktifkan atau hapus panah jika bertabrakan dengan objek endpoint
            Destroy(collision.gameObject); // Hapus panah objek dari scene
         }
     }
}
