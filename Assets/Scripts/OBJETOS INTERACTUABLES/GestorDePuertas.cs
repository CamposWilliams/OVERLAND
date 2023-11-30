using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestorDePuertas : MonoBehaviour
{

    private Animator AnimacionPuerta;
    public GameObject bloqueador;




    private void Start()
    {
        AnimacionPuerta = GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AnimacionPuerta.SetBool("Abierto", true);
            gameObject.layer = 11;
            bloqueador.SetActive(false);
            Debug.Log("EstaDentro");

            // Llama al escaneo después de cambiar la capa
            GetComponent<EscaneoNavegacion>().RealizarEscaneo();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AnimacionPuerta.SetBool("Abierto", false);
            gameObject.layer = 8;
            bloqueador.SetActive(true);
            Debug.Log("EstaFuera");

            // Llama al escaneo después de cambiar la capa
            GetComponent<EscaneoNavegacion>().RealizarEscaneo();
        }
    }



}
