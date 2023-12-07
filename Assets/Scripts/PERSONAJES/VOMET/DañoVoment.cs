using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoVoment : MonoBehaviour
{
    public AIPath aiPath;
    float dañoPorGolpe = 3;
    float time1;
    float time2;
    public float tiempoParaVolverADisparar = 5;
    float cadenciaDeTiro = 0.85f;
    Animator VomentAnimator;
    bool disparando;
    public GameObject balaGordock;
    float contador;
    bool puedeDisparar = true;
    float contador2;
    private void Start()
    {
        VomentAnimator = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<SistemaDeVida>().BajarVida(dañoPorGolpe);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Entre");
            disparando = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            disparando = false;
        }

    }
    private void Update()
    {
        //Debug.Log(time1);
        DispararGordock();
        ReactivarAnimacionYBala();
    }

    void DispararGordock()
    {
        if (disparando)
        {

            if (puedeDisparar)
            {
                aiPath.maxSpeed = 0;
                VomentAnimator.SetBool("SeMueve", false);
                VomentAnimator.SetBool("Disparando", true);
                
                contador++;
                puedeDisparar = false;


            }

        }

    }

    void ReactivarAnimacionYBala()
    {

        if (!puedeDisparar)
        {
            time1 += Time.deltaTime;

            if ((time1 >= cadenciaDeTiro && time1 < tiempoParaVolverADisparar) && contador == 1)
            {

                GameObject nuevaBala = Instantiate(balaGordock);
                nuevaBala.transform.position = transform.position;
                nuevaBala.GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<SeguirAstar>().valorDelParametroX, GetComponent<SeguirAstar>().valorDelParametroY) * 5;
                Destroy(nuevaBala, 1);
                if (contador2 == 0)
                {
                    Destroy(nuevaBala);
                }
                contador2++;
                contador = 0;
            }

            if (time1 >= tiempoParaVolverADisparar)
            {
                puedeDisparar = true;
                time1 = 0;
            }


            if (VomentAnimator.GetBool("Disparando"))
            {
                time2 += Time.deltaTime;

                if (time2 >= 1)
                {
                    VomentAnimator.SetBool("Disparando", false);
                    VomentAnimator.SetBool("SeMueve", true);
                    aiPath.maxSpeed = 1.5f;
                    time2 = 0;
                }
            }



        }


    }

}
