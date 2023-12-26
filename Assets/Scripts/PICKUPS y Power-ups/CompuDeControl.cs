using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompuDeControl : MonoBehaviour
{
    public int contador = 0;
    public bool ponerContadorDeTarjetasEnCero;
    public GameObject GasToxico;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (contador == 2 && Input.GetKey("e"))
            {
               
                ponerContadorDeTarjetasEnCero = true;
                Destroy(GasToxico);
            }

        }

    }
}