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
    int contador;
    private void Start()
    {
        bonkAnimacion = GetComponent<Animator>();
        spriteBonk = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bala_player"))
        {

            saludBonk--;
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
