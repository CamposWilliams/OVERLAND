using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    string color;
    public GameObject prefabBala;
    public GameObject Mike;
   float CdPU=5;
    float tiempo;
   public bool conPU = false;
    float cd;
    SpriteRenderer sprPowerUp;
    Collider2D collPowerUp;

    private void Start()
    {
        sprPowerUp = GetComponent<SpriteRenderer>();
        collPowerUp = GetComponent<Collider2D>();
        color=gameObject.name;
        Debug.Log(color);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("colisione");

            switch (color)
            {
                //case "PociónAzul":
                //    collision.GetComponent<PlayerVida>().PUAzul = true;
                //    Destroy(gameObject);
                //    break;
                case "PociónMorada":

                    conPU = true;
                    sprPowerUp.enabled = false;
                    collPowerUp.enabled = false;
                    cd = Mike.GetComponent<JugadorDisparo>().cdDisparo;
                    Mike.GetComponent<JugadorDisparo>().cdDisparo = cd /3;

                    //Debug.Log(conPU);
                    ;
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
    private void Update()
    {
        ActivarDesactivarPowerUp();
    }

    void ActivarDesactivarPowerUp()
    {
        
        if (conPU==true)
        {
            prefabBala.GetComponent<JugadorBala>().PUMorado = true;

            tiempo += Time.deltaTime;

            if (tiempo >=CdPU)
            {
                Debug.Log("Hola");
                prefabBala.GetComponent<JugadorBala>().PUMorado = false;
                Mike.GetComponent<JugadorDisparo>().cdDisparo = cd;
                tiempo = 0;
                conPU = false;
                Destroy(gameObject);
            }
        }
        
    }

}
