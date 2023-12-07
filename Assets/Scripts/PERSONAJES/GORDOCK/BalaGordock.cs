using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaGordock : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<SistemaDeVida>().BajarVida(1);
            Destroy(gameObject);
        }
        if (collision.CompareTag("TileCollider"))
        {
            Destroy(gameObject);
        }
    }
}
