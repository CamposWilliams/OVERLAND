using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaBonk : MonoBehaviour
{
  public  float saludBonk=5;
  Animator bonkAnimacion;
  SpriteRenderer spriteBonk;
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
            
            
                
        }
        if (saludBonk <= 0)
        {
            GetComponent<Collider2D>().enabled = false;
            GetComponentInParent<Seguir>().navMeshAgent.speed = 0;
            StartCoroutine(AnimacionDeMuerte());
        }

        else if (collision.CompareTag("Espada"))
        {
            saludBonk-=3;
            StartCoroutine(CambiarColor());
        }
    }

    IEnumerator AnimacionDeMuerte()
    {
        bonkAnimacion.SetBool("EstaSinVida", true);


             
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

    IEnumerator CambiarColor()
    {
        spriteBonk.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spriteBonk.color=Color.white;
    }
}
