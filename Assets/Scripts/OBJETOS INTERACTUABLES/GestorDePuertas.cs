using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestorDePuertas : MonoBehaviour
{

    private Animator AnimacionPuerta;



    private void Start()
    {
        AnimacionPuerta = GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            AnimacionPuerta.SetBool("Abierto", true);
            GetComponentInChildren<Collider2D>().enabled = false;
            Debug.Log("EstaDentro");
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            AnimacionPuerta.SetBool("Abierto", false);
            GetComponentInChildren<Collider2D>().enabled = true;

        }

    }



}
