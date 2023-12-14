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
        if ((muriendo2 && contador == 0) && valor==2)
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
            switch (numeroDeBala)
            {
                case 0: saludGordock--; break;
                case 1: saludGordock--; break;
                case 2: saludGordock -= 5; break;
                case 3: saludGordock -= 8; break;
            }
            StartCoroutine(CambiarColor());
            Destroy(collision.gameObject);



        }
        if (saludGordock <= 0)
        {
            muriendo = true;
            GetComponent<Collider2D>().enabled = false;
            GetComponent<AIPath>().maxSpeed = 0;
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