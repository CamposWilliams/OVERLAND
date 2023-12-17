using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class VidaVoment : MonoBehaviour
{
    public float saludVoment = 5;
    Animator VomentAnimacion;
    public GameObject Mike;
    SpriteRenderer spriteVoment;
    public bool muriendo = false;
    public Collider2D[] Areas;
    public bool AreaDeDaño;
    public bool dentroDelAcido;
    float time;
    float numeroDeBala;
    public GameObject sangreDisparada;
    private void Awake()
    {
        Mike = GameObject.Find("Mike");
    }
    private void Start()
    {
        VomentAnimacion = GetComponent<Animator>();
        spriteVoment = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
      
        //Debug.Log(time);
        DañoZonaAcida();
        numeroDeBala = Mike.GetComponent<JugadorDisparo>().CambioArma;
    }
    void DañoZonaAcida()
    {
        if (dentroDelAcido)
        {
            if (AreaDeDaño)
            {
                time += Time.deltaTime;

                if (time >= 0.4f)
                {
                    Mike.GetComponent<SistemaDeVida>().BajarVida(1);
                    time = 0;
                }

            }

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
                case 0: saludVoment--; break;
                case 1: saludVoment--; break;
                case 2: saludVoment -= 5; break;
                case 3: saludVoment -= 8; break;
            }
            StartCoroutine(CambiarColor());

            Destroy(collision.gameObject);         

        }
        if (collision.CompareTag("Player") && AreaDeDaño)
        {
            Mike.GetComponent<SistemaDeVida>().BajarVida(1);
            dentroDelAcido =true;
        }

        if (saludVoment <= 0)
        {
            muriendo = true;
            GetComponent<Collider2D>().isTrigger = true;
            foreach (Collider2D collider2D in Areas)
            {
               collider2D.enabled = false;
            }
            AreaDeDaño = true;
            GetComponent<AIPath>().maxSpeed = 0;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            StartCoroutine(AnimacionDeMuerte());
        }

        else if (collision.CompareTag("Espada"))
        {
            saludVoment-=3;
            StartCoroutine(CambiarColor());
        }
    }




    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dentroDelAcido = false;
            time = 0;
        }
    }

    IEnumerator AnimacionDeMuerte()
    {
        VomentAnimacion.SetBool("EstaSinVida", true);
        gameObject.layer = 17;

        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

    IEnumerator CambiarColor()
    {
       
            spriteVoment.color = Color.red;
            yield return new WaitForSeconds(0.2f);
            spriteVoment.color = Color.white;
        
       
    }

    
}
