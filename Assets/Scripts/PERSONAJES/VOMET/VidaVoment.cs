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
    private void Start()
    {
        VomentAnimacion = GetComponent<Animator>();
        spriteVoment = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        //Debug.Log(time);
        DañoZonaAcida();
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
            saludVoment--;
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

        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }

    IEnumerator CambiarColor()
    {
       
            spriteVoment.color = Color.red;
            yield return new WaitForSeconds(0.2f);
            spriteVoment.color = Color.white;
        
       
    }

    
}
