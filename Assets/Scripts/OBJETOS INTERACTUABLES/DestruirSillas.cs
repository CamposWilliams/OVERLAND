using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirSillas : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bala_player"))
        {
            Destroy(gameObject);
        }
    }
}
