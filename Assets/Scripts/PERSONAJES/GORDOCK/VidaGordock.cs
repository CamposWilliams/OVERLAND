using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class VidaGordock : MonoBehaviour
{
    public float saludGordock = 5;
    Animator GordockAnimacion;
    SpriteRenderer spriteGordock;
    public bool muriendo=false;
    bool muriendo2;
    public GameObject municionEspecial;
    float contador;
    float valor;
    float numeroDeBala;
    public GameObject Mike;
    public GameObject sangreDisparada;

    private void Awake()
    {
        Mike = GameObject.Find("Mike");
    }
    private void Start()
    {
        
        GordockAnimacion = GetComponent<Animator>();
        spriteGordock = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        BotarMunicion();
        numeroDeBala = Mike.GetComponent<JugadorDisparo>().CambioArma;
    }

    void BotarMunicion()
    {
        if ((muriendo2 && contador == 0) && (valor == 2 || valor==1))
        {
            contador++;
            GameObject municionSuelta = Instantiate(municionEspecial);
            municionSuelta.transform.position = transform.position;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bala_player"))
        {
            if (Mike.GetComponent<MikeDisparo>().anguloConstante == 0)
            {
                GameObject nuevaSangre = Instantiate(sangreDisparada);
                nuevaSangre.transform.position = collision.transform.position;
                nuevaSangre.GetComponent<SpriteRenderer>().flipX = true;
                Destroy(nuevaSangre, 0.25f);
            }

            if (Mike.GetComponent<MikeDisparo>().anguloConstante == 90)
            {
                GameObject nuevaSangre = Instantiate(sangreDisparada);
                nuevaSangre.transform.position = collision.transform.position;
                nuevaSangre.transform.Rotate(Vector3.forward * 90);
                Destroy(nuevaSangre, 0.25f);
            }
            if (Mike.GetComponent<MikeDisparo>().anguloConstante == 180)
            {
                GameObject nuevaSangre = Instantiate(sangreDisparada);
                nuevaSangre.transform.position = collision.transform.position;
                nuevaSangre.GetComponent<SpriteRenderer>().flipX = false;
                Destroy(nuevaSangre, 0.25f);
            }
            if (Mike.GetComponent<MikeDisparo>().anguloConstante == 270)
            {
                GameObject nuevaSangre = Instantiate(sangreDisparada);
                nuevaSangre.transform.position = collision.transform.position;
                nuevaSangre.transform.Rotate(Vector3.forward * 270);
                Destroy(nuevaSangre, 0.25f);
            }
            switch (numeroDeBala)
            {
                case 0: saludGordock-=10f; break;
                case 1: saludGordock--; break;
                case 2: saludGordock -= 15; break;
                case 3: saludGordock -= 10; break;
            }
            StartCoroutine(CambiarColor());
            Destroy(collision.gameObject);



        }
        if (saludGordock <= 0)
        {
            muriendo = true;
            GetComponent<Collider2D>().enabled = false;
            GetComponent<AIPath>().maxSpeed = 0;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            StartCoroutine(AnimacionDeMuerte());
        }

        else if (collision.CompareTag("Espada"))
        {
            saludGordock -= 3;
            StartCoroutine(CambiarColor());
        }
    }

    IEnumerator AnimacionDeMuerte()
    {
        GordockAnimacion.SetBool("EstaSinVida", true);
        //yield return new WaitForSeconds(0.015f);
        //GordockAnimacion.SetBool("EstaSinVida", false);    

        yield return new WaitForSeconds(1.7f);
        spriteGordock.enabled = false;
        muriendo2=true;
        valor=Random.Range(1, 3);

        
        Destroy(gameObject,0.1f);
    }

    IEnumerator CambiarColor()
    {
        spriteGordock.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spriteGordock.color = Color.white;
    }
}