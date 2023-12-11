using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivadorDeEnemigos : MonoBehaviour
{
    private List<GameObject> enemigosDesactivados = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo1"))
        {
            if (enemigosDesactivados.Contains(collision.gameObject))
            {
                collision.gameObject.SetActive(true);
                enemigosDesactivados.Remove(collision.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo1"))
        {
            collision.gameObject.SetActive(false);
            enemigosDesactivados.Add(collision.gameObject);
        }
    }
}
