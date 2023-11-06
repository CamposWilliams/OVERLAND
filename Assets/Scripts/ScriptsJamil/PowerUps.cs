using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    string color;
    public GameObject prefabBala;

    private void Start()
    {
        color=gameObject.name;
        Debug.Log(color);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            switch (color)
            {
                //case "Poci�nAzul":
                //    collision.GetComponent<PlayerVida>().PUAzul = true;
                //    Destroy(gameObject);
                //    break;
                case "Poci�nMorada":
                    prefabBala.GetComponent<JugadorBala>().PUMorado = true;
                    Destroy(gameObject);
                    break;
                //case "Poci�nVerde":
                //    collision.GetComponent<JugadorMovimiento>().PUVerde = true;
                //    Destroy(gameObject);
                //    break;
                //case "Botiqu�n":
                //    collision.GetComponent<PlayerVida>().vidaActual = collision.GetComponent<PlayerVida>().vidaInicial;
                //    break;
            }
        }

    }
}
