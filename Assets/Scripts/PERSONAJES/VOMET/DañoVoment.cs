using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaņoVoment : MonoBehaviour
{
    float daņoPorGolpe = 3;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<SistemaDeVida>().BajarVida(daņoPorGolpe);
        }
    }

}
