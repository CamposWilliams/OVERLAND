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
    float rapidez=0;
    float rapidezBala;
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
            conPU = true;

            switch (color)
            {
                //case "PociónAzul":
                //    collision.GetComponent<PlayerVida>().PUAzul = true;
                //    Destroy(gameObject);
                //    break;
                case "PociónMorada":

                    sprPowerUp.enabled = false;
                    collPowerUp.enabled = false;
                    cd = Mike.GetComponent<JugadorDisparo>().cdDisparo;
                    Mike.GetComponent<JugadorDisparo>().cdDisparo = cd /3;
                    rapidezBala = prefabBala.GetComponent<JugadorBala>().rapidez;
                    prefabBala.GetComponent<JugadorBala>().rapidez = rapidezBala * 3;

                    break;
                //Debug.Log(conPU);


                case "PociónVerde":
                   
                    sprPowerUp.enabled = false;
                    collPowerUp.enabled = false;
                    rapidez=collision.GetComponent<JugadorMovimiento>().rapidez;
                    collision.GetComponent<JugadorMovimiento>().rapidez=rapidez*2;
                    
                    break;
                    //case "Botiquín":
                    //    collision.GetComponent<PlayerVida>().vidaActual = collision.GetComponent<PlayerVida>().vidaInicial;
                    //    break;
            }


        }
    }
    private void Update()
    {
        DesactivarPowerUpMorado();
        DesactivarPowerUpAzul();
        DesactivarPowerUpVerde();
    }

    void DesactivarPowerUpMorado()
    {
        
        if (/*conPU==true &&*/ cd!=0)
        {

            tiempo += Time.deltaTime;

            if (tiempo >=CdPU)
            {
                Debug.Log("Desactivado Morado");
                prefabBala.GetComponent<JugadorBala>().rapidez = rapidezBala;
                Mike.GetComponent<JugadorDisparo>().cdDisparo = cd;
                tiempo = 0;
                cd=0;
                Destroy(gameObject);
            }
        }
        
    }

    void DesactivarPowerUpAzul()
    {

    }
    void DesactivarPowerUpVerde()
    {
        if (/*conPU == true && */rapidez!=0)
        {
            tiempo += Time.deltaTime;

            if (tiempo >= CdPU)
            {
                Debug.Log("Desactivado Verde");

                Mike.GetComponent<JugadorMovimiento>().rapidez = rapidez;
                rapidez = 0;
                Destroy(gameObject);
                
            }
        }
    }

}
