using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tarjetas : MonoBehaviour
{
    public GameObject Computadora;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Computadora.GetComponent<CompuDeControl>().contador++;
            Destroy(gameObject);
        }
    }
}
