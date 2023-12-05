using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Botiquín : MonoBehaviour
{
    float curación=17;
    public Animator Mike;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(InciarDesactivacion());
            collision.GetComponent<SistemaDeVida>().AumentarVida(curación);
            Mike.SetBool("ConPU", true);
            Mike.SetFloat("PU", 3);
            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            
           
            
        }

         IEnumerator InciarDesactivacion()
        {
            yield return new WaitForSeconds(1);
            Mike.SetBool("ConPU", false);
            Destroy(gameObject);
        }

    }
}
