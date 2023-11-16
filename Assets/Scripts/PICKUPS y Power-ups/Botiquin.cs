using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botiquín : MonoBehaviour
{
    float curación=5;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<SistemaDeVida>().AumentarVida(curación);
        }
        Debug.Log("Choque");
        Destroy(gameObject);

    }
}
