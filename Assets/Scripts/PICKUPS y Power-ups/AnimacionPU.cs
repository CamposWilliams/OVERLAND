using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionPU : MonoBehaviour
{
   public Animator disfrazAnimator;
    GameObject Mike;
    private void Awake()
    {
        Mike = GameObject.Find("Mike");
    }

    private void Update()
    {
        if (Mike.GetComponent<SistemaDeVida>().vidaActualMike <= 0)
        {
            disfrazAnimator.SetBool("ConPU", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PocionAmarilla"))
        {
            Debug.Log("Hola");
            disfrazAnimator.SetBool("ConPU", true);           
            disfrazAnimator.SetFloat("PU", 0);
            
            StartCoroutine(AnimacionesPU());
        }
        else if (collision.CompareTag("PocionAzul"))
        {
            Debug.Log("Hola");
            disfrazAnimator.SetBool("ConPU", true);           
            disfrazAnimator.SetFloat("PU", 1);
            StartCoroutine(AnimacionesPU());
        }
       else if (collision.CompareTag("PocionMorada"))
        {
             Debug.Log("Hola");
            disfrazAnimator.SetBool("ConPU", true);
            disfrazAnimator.SetFloat("PU", 2);
            StartCoroutine(AnimacionesPU());
        }

        else if (collision.CompareTag("BotiquinTag"))
        {
            Debug.Log("Hola");
           
            disfrazAnimator.SetBool("ConPU", true);
            disfrazAnimator.SetFloat("PU", 3);
            StartCoroutine(AnimacionesPU());
        }

        
    }
    IEnumerator AnimacionesPU()
    {
        Debug.Log("Adios");
        yield return new WaitForSeconds(5);
        disfrazAnimator.SetBool("ConPU", false);
    }
}
