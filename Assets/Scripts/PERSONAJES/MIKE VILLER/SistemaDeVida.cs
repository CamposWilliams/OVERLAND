using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SistemaDeVida : MonoBehaviour
{
   public float vidaM�ximaMike=10;
   public float vidaActualMike;
   float da�oEntrante;
   public bool PUAzulActivo;
   public bool sinVida;

    public Image barraDeVida;

    void Start()
    {
        vidaActualMike = vidaM�ximaMike;
        //ActualizarBarraDeVida();
    }

     public void BajarVida(float da�o)
    {
        if(PUAzulActivo)
        {
            da�oEntrante = da�o/2;
        }
        else
        {
            da�oEntrante = da�o;
        }
        //Debug.Log($"Recibiste {da�oEntrante} de da�o");
        vidaActualMike -= da�oEntrante;
       
        if( vidaActualMike <= 0)
        {
            sinVida = true;
            GetComponent<Collider2D>().enabled = false;
            StartCoroutine(Muriendo());
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            
        }
        //ActualizarBarraDeVida();
    }
    //void ActualizarBarraDeVida()
    //{
    //    float porcentajeVida = vidaActualMike / vidaM�ximaMike;
    //    barraDeVida.fillAmount = porcentajeVida;
    //}
    IEnumerator Muriendo()
    {
        GetComponent<Animator>().SetBool("Muere", true);
        yield return new WaitForSeconds(0.1f);
        GetComponent<Animator>().SetBool("Muere", false);
        yield return new WaitForSeconds(0.9f);
        gameObject.SetActive(false);

    }
    public void AumentarVida(float vida)
    {
        Debug.Log($"Recibiste {vida} de salud");
        vidaActualMike += vida;
        
        if (vidaActualMike <= 0)
        {
            gameObject.SetActive(false);
        }
        //ActualizarBarraDeVida();
    }

    
}
