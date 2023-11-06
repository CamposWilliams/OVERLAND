using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class JugadorBala : MonoBehaviour
{
    public float rapidez;
    Rigidbody2D rb2dBala;
    public Vector2 direction;
    public float tiempo;
    public float temporizador;

    public GameObject bulletPrefab;
    public bool PUMorado = false;
    public float cdPUM = 5;
    
    void Start()
    {
        rb2dBala = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        Movimiento();
        Temporizador();
        Debug.Log(rb2dBala.velocity.sqrMagnitude);
    }
  
    void Movimiento()
    {
        rb2dBala.velocity = direction * rapidez;

        if (PUMorado == false)
        {
            rb2dBala.velocity = direction * rapidez;

        }
        else
        {
            rb2dBala.velocity = direction * rapidez*2;
            //cdDisparo = cdDisparo / 2;
        }
    }

    void Temporizador()
    {
        tiempo += Time.deltaTime;
        if (tiempo >= temporizador)
        {
            Destroy(gameObject);
        }
    }



}
