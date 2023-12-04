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
    private void Start()
    {
        GordockAnimacion = GetComponent<Animator>();
        spriteGordock = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bala_player"))
        {

            saludGordock--;
            StartCoroutine(CambiarColor());
            Destroy(collision.gameObject);



        }
        if (saludGordock <= 0)
        {
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
        yield return new WaitForSeconds(0.015f);
        GordockAnimacion.SetBool("EstaSinVida", false);    

        yield return new WaitForSeconds(1.9f);
        Destroy(gameObject);
    }

    IEnumerator CambiarColor()
    {
        spriteGordock.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spriteGordock.color = Color.white;
    }
}