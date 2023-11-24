using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaVoment : MonoBehaviour
{
    public float saludVoment = 5;
    Animator VomentAnimacion;
    SpriteRenderer spriteVoment;
    private void Start()
    {
        VomentAnimacion = GetComponent<Animator>();
        spriteVoment = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bala_player"))
        {
            saludVoment--;
            StartCoroutine(CambiarColor());

            Destroy(collision.gameObject);

            if (saludVoment <= 0)
            {
                StartCoroutine(AnimacionDeMuerte());
            }

        }

        else if (collision.CompareTag("Espada"))
        {
            saludVoment--;
            StartCoroutine(CambiarColor());
        }
    }

    IEnumerator AnimacionDeMuerte()
    {
        VomentAnimacion.SetBool("EstaSinVida", true);
        GetComponent<SeguimimietoAMikeVoment>().enabled = false;
        GetComponent<SeguimimietoAMikeVoment>().rapidezBonk = 0;


        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    IEnumerator CambiarColor()
    {
        spriteVoment.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spriteVoment.color = Color.white;
    }
}
