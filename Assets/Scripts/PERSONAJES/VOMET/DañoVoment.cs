using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoVoment : MonoBehaviour
{
    public AIPath aiPath;
    float dañoPorGolpe = 3;
    float time1;
    public float tiempoParaVolverADisparar = 5;
    float cadenciaDeTiro = 0.3f;
    Animator VomentAnimator;
    bool disparando;
    public GameObject balaGordock;
    bool puedeDisparar = true;

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
                GameObject nuevaBala = Instantiate(balaGordock);
                nuevaBala.transform.position = transform.position;
                nuevaBala.GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<SeguirAstar>().valorDelParametroX, GetComponent<SeguirAstar>().valorDelParametroY) * 5;
                Destroy(nuevaBala,1);
                puedeDisparar = false;

            }

        }

    }

    void ReactivarAnimacionYBala()
    {

        if (!puedeDisparar)
        {
            time1 += Time.deltaTime;

            if (time1 >= cadenciaDeTiro)
            {

                puedeDisparar = true;
                time1 = 0;
            }

           
        }


    }

}
