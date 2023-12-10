using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Botiquín : MonoBehaviour
{
    float curación=17;
    public Animator MikeAnimator;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log(gameObject.name);
            StartCoroutine(InciarDesactivacion());
            collision.GetComponent<SistemaDeVida>().AumentarVida(curación);
            MikeAnimator.SetBool("ConBotiquin", true);
            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            
           
            
        }

         IEnumerator InciarDesactivacion()
        {
            yield return new WaitForSeconds(1);
            MikeAnimator.SetBool("ConBotiquin", false);
            Destroy(gameObject);
        }

    }
}
