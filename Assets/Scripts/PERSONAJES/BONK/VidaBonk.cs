using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class VidaBonk : MonoBehaviour
{

    public float saludBonk = 5;
    Animator bonkAnimacion;
    SpriteRenderer spriteBonk;
    public AudioSource MuertoSonido;
    public Collider2D BonkCollider;
    public float numeroDeBala;
    int contador;
    public GameObject Mike;
    public GameObject sangreDisparada;

    private void Awake()
    {
        Mike = GameObject.Find("Mike");
    }
    private void Start()
    {
        //Debug.Log(numeroDeBala);
        bonkAnimacion = GetComponent<Animator>();
        spriteBonk = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        numeroDeBala = Mike.GetComponent<JugadorDisparo>().CambioArma;
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
                case 0:saludBonk --; break;
                case 1:saludBonk --; break;
                case 2: saludBonk -=5; break;
                case 3: saludBonk -=8; break;
            }
            StartCoroutine(CambiarColor());
            Destroy(collision.gameObject);

            if (saludBonk <= 0)
            {

                contador++;
                if (contador == 1)
                {
                    Destroy(BonkCollider);
                    GetComponent<AIPath>().maxSpeed = 0;
                    GetComponent<AIPath>().enabled = false;
                    GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                    StartCoroutine(AnimacionDeMuerte());
                    MuertoSonido.Play();

                }



            }

        }


        else if (collision.CompareTag("Espada"))
        {
            saludBonk -= 3;
            StartCoroutine(CambiarColor());
        }
    }

    IEnumerator AnimacionDeMuerte()
    {

        bonkAnimacion.SetBool("EstaSinVida", true);
        //yield return new WaitForSeconds(0.015f);
        //bonkAnimacion.SetBool("EstaSinVida", false);

        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    IEnumerator CambiarColor()
    {
        spriteBonk.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spriteBonk.color = Color.white;
    }
   
}
