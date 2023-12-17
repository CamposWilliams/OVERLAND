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
    public bool Confirmación;
    int contadorUnico;
    int contadorUnico2;
    public bool verificado;

    private void Update()
    {
        Debug.Log(contadorUnico);
    }

    private void Start()
    {
        AnimacionPuerta = GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            contadorUnico++;
            if (contadorUnico == 1 && verificado)
            {
                AnimacionPuerta.SetBool("Abierto", true);
                gameObject.layer = 11;
                bloqueador.SetActive(false);
            }
        }

        if (collision.CompareTag("Player") || collision.CompareTag("Enemigo1"))
        {
            contadorEntran++;
           
          
            if(Confirmación || !verificado)
            {
                AnimacionPuerta.SetBool("Abierto", true);
                gameObject.layer = 11;
                bloqueador.SetActive(false);
            }

           
                      
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
           

            if (contadorEntran==contadorSalen && (Confirmación || !verificado))
            {
                
                CERRAR.Play();
                AnimacionPuerta.SetBool("Abierto", false);
                gameObject.layer = 8;
                bloqueador.SetActive(true);

            }     

            if(contadorEntran == contadorSalen)
            {
                contadorEntran = 0;
                contadorSalen = 0;

            }

            GetComponent<EscaneoNavegacion>().RealizarEscaneo();
        }
       

        if (collision.CompareTag("Player"))
        {
            contadorUnico2++;
            if (contadorUnico2 == 1 && verificado)
            {
                CERRAR.Play();
                AnimacionPuerta.SetBool("Abierto", false);
                gameObject.layer = 8;
                bloqueador.SetActive(true);
                //contadorEntran = 0;
                //contadorSalen = 0;
                
            }

            if (verificado)
            {
                AnimacionPuerta.SetBool("Abierto", false);
                gameObject.layer = 8;
                bloqueador.SetActive(true);
                //contadorEntran = 0;
                //contadorSalen = 0;
            }
        }
    }



}
