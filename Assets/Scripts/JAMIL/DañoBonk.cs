using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonkDa�o : MonoBehaviour
{
    float da�oPorGolpe=3;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<SistemaDeVida>().BajarVida(da�oPorGolpe);
        }
    }
}
