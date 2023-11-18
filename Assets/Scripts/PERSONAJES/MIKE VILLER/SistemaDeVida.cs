using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaDeVida : MonoBehaviour
{
   public float vidaM�ximaMike=10;
   public float vidaActualMike;
   float da�oEntrante;
   public bool PUAzulActivo;

    void Start()
    {
        vidaActualMike = vidaM�ximaMike;
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
            gameObject.SetActive(false);
        }
    }

     public void AumentarVida(float vida)
    {
        Debug.Log($"Recibiste {vida} de salud");
        vidaActualMike += vida;
        
        if (vidaActualMike <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    
}
