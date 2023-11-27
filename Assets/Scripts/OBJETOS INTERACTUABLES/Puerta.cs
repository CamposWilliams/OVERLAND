using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{

    public Animator doorAnimator;

    private void Start()
    {
        doorAnimator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (CompareTag("Player"))
        {
            // Abre la puerta
            doorAnimator.SetBool("Abierto",true);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (CompareTag("Player"))
        {
            // Cierra la puerta
            doorAnimator.SetBool("Abierto", false);
        }
    }
}

