using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestorDePuertas : MonoBehaviour
{
    public AudioSource ABRIR;
    public AudioSource CERRAR;
    private Animator AnimacionPuerta;
    public GameObject bloqueador;
    float contadorEntran;
    float contadorSalen;




    private void Start()
    {
        AnimacionPuerta = GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Enemigo1"))
        {
            contadorEntran++;
            
            AnimacionPuerta.SetBool("Abierto", true);
            gameObject.layer = 11;
            bloqueador.SetActive(false);
            //Debug.Log("EstaDentro");

            // Llama al escaneo después de cambiar la capa
            GetComponent<EscaneoNavegacion>().RealizarEscaneo();
        }
        if (contadorEntran == 1)
        {
            ABRIR.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Enemigo1"))
        {
            contadorSalen++;
            if(contadorEntran==contadorSalen)
            {
                CERRAR.Play();
                AnimacionPuerta.SetBool("Abierto", false);
                gameObject.layer = 8;
                bloqueador.SetActive(true);
                contadorEntran = 0;
                contadorSalen = 0;
            }
           
            //Debug.Log("EstaFuera");

            // Llama al escaneo después de cambiar la capa
            GetComponent<EscaneoNavegacion>().RealizarEscaneo();
        }
    }



}
