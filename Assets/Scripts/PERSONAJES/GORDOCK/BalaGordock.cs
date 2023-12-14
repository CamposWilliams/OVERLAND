using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaGordock : MonoBehaviour
{

    public float contadorGordock;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           if(contadorGordock%2==0)
            {
                collision.GetComponent<SistemaDeVida>().BajarVida(1);
                Destroy(gameObject);
            }
            else
            {
                collision.GetComponent<SistemaDeVida>().BajarVida(3);
                Destroy(gameObject);
            }
            
        }
        if (collision.CompareTag("TileCollider"))
        {
            Destroy(gameObject);
        }
    }
}
