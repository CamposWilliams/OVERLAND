using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Botiquín : MonoBehaviour
{
    float curación=25;
    public Animator DisfrazBotiquin;
    GameObject reactivador;
    int contador;
    
    private void Awake()
    {
       
        reactivador = GameObject.Find("ReactivarObjetos");
        DisfrazBotiquin = GameObject.Find("DisfrazBotiquin").GetComponent<Animator>();
    }
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log(gameObject.name);
            StartCoroutine(InciarDesactivacion());
            collision.GetComponent<SistemaDeVida>().AumentarVida(curación);
            DisfrazBotiquin.SetBool("ConBotiquin", true);
            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            
           
            
        }

         IEnumerator InciarDesactivacion()
        {
            yield return new WaitForSeconds(1);
            DisfrazBotiquin.SetBool("ConBotiquin", false);
            reactivador.GetComponent<ActivarObjetos>().botiquin.Add(gameObject);
            reactivador.GetComponent<ActivarObjetos>().botiquinTrf.Add(gameObject.transform);
            
            gameObject.SetActive(false);
     
        }

    }
}
