using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SistemaDeVida : MonoBehaviour
{
   public float vidaMáximaMike=10;
   public float vidaActualMike;
   float dañoEntrante;
   public bool PUAzulActivo;

    public Image barraDeVida;

    void Start()
    {
        vidaActualMike = vidaMáximaMike;
        ActualizarBarraDeVida();
    }

     public void BajarVida(float daño)
    {
        if(PUAzulActivo)
        {
            dañoEntrante = daño/2;
        }
        else
        {
            dañoEntrante = daño;
        }
        //Debug.Log($"Recibiste {dañoEntrante} de daño");
        vidaActualMike -= dañoEntrante;
       
        if( vidaActualMike <= 0)
        {
            gameObject.SetActive(false);
        }
        ActualizarBarraDeVida();
    }
    void ActualizarBarraDeVida()
    {
        float porcentajeVida = vidaActualMike / vidaMáximaMike;
        barraDeVida.fillAmount = porcentajeVida;
    }

    public void AumentarVida(float vida)
    {
        Debug.Log($"Recibiste {vida} de salud");
        vidaActualMike += vida;
        
        if (vidaActualMike <= 0)
        {
            gameObject.SetActive(false);
        }
        ActualizarBarraDeVida();
    }

    
}
