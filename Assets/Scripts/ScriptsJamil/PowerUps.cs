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
                //case "PociónAzul":
                //    collision.GetComponent<PlayerVida>().PUAzul = true;
                //    Destroy(gameObject);
                //    break;
                case "PociónMorada":
                    prefabBala.GetComponent<JugadorBala>().PUMorado = true;
                    Destroy(gameObject);
                    break;
                //case "PociónVerde":
                //    collision.GetComponent<JugadorMovimiento>().PUVerde = true;
                //    Destroy(gameObject);
                //    break;
                //case "Botiquín":
                //    collision.GetComponent<PlayerVida>().vidaActual = collision.GetComponent<PlayerVida>().vidaInicial;
                //    break;
            }
        }

    }
}
