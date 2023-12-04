using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestorDePuertas : MonoBehaviour
{
    public AudioSource ABRIR;
    public AudioSource CERRAR;
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
            ABRIR.Play();
            AnimacionPuerta.SetBool("Abierto", true);
            gameObject.layer = 11;
            bloqueador.SetActive(false);
            //Debug.Log("EstaDentro");

            // Llama al escaneo después de cambiar la capa
            GetComponent<EscaneoNavegacion>().RealizarEscaneo();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CERRAR.Play();
            AnimacionPuerta.SetBool("Abierto", false);
            gameObject.layer = 8;
            bloqueador.SetActive(true);
            //Debug.Log("EstaFuera");

            // Llama al escaneo después de cambiar la capa
            GetComponent<EscaneoNavegacion>().RealizarEscaneo();
        }
    }



}
