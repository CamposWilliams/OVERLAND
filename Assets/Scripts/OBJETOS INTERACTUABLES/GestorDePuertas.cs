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
    bool condicionDeSonar;
   

    private void Update()
    {
        //Debug.Log(contadorUnico);
        AbrirPuertas();
        if (verificado == false && Confirmación==false)
        {
            condicionDeSonar=true;
        }
        else if( verificado==true && Confirmación == false)
        {
            condicionDeSonar = false;
        }
        else
        {
            condicionDeSonar = true;
        }
    }

    private void Start()
    {
        AnimacionPuerta = GetComponent<Animator>();
    }
    void AbrirPuertas()
    {
        if (Confirmación && contadorUnico==0)
        {
            AnimacionPuerta.SetBool("Abierto", true);
            gameObject.layer = 11;
            bloqueador.SetActive(false);
            contadorUnico++;
        }

        if (verificado && contadorUnico2==0)
        {
            AnimacionPuerta.SetBool("Abierto", false);
            gameObject.layer = 8;
            bloqueador.SetActive(true);
            contadorUnico2++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player") || collision.CompareTag("Enemigo1"))
        {
            contadorEntran++;
                  
            if(Confirmación || !verificado)
            {
               
                AnimacionPuerta.SetBool("Abierto", true);
                gameObject.layer = 11;
                bloqueador.SetActive(false);
            }
           


            GetComponent<EscaneoNavegacion>().RealizarEscaneo();
        }
        
         if (contadorEntran == 1 && condicionDeSonar)
         {
            ABRIR.Play();
         }
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Enemigo1"))
        {
            contadorSalen++;
           

            if (contadorEntran==contadorSalen)
            {
                if(condicionDeSonar) CERRAR.Play();
                AnimacionPuerta.SetBool("Abierto", false);
                gameObject.layer = 8;
                bloqueador.SetActive(true);
                contadorEntran = 0;
                contadorSalen = 0;
            }     
           
            GetComponent<EscaneoNavegacion>().RealizarEscaneo();
        }
       

    }



}
