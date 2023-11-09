using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonkDaño : MonoBehaviour
{
    float dañoPorGolpe=3;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<SistemaDeVida>().BajarVida(dañoPorGolpe);
        }
    }
}
