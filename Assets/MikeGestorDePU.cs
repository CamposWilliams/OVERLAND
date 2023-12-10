using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MikeGestorDePU : MonoBehaviour
{
    public float contadorAzul;
    public float contadorMorado;
    public float contadorAmarillo;
    public float suma;
    public Animator disfrazAnimator;

    private void Update()
    {
        suma = contadorAmarillo + contadorMorado + contadorAzul;
        AnimacionesPU();
        //Debug.Log(suma);
    }
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PocionAzul"))
        {
            contadorAzul++;
        }
        if (collision.CompareTag("PocionAmarilla"))
        {
            //Debug.Log("ChoqueAmarillo");
            contadorAmarillo++;
        }
        if (collision.CompareTag("PocionMorada"))
        {
            contadorMorado++;   
        }

    }

    void AnimacionesPU()
    {
        if (suma == 0)
        {
            //Debug.Log("DesactivandoAnimacion");
            disfrazAnimator.SetBool("ConPU", false);
        }
      
    }



}
