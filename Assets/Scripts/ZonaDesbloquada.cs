using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaDesbloquada : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            GetComponent<Renderer>().enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<Renderer>().enabled = true;
        }
    }
}
