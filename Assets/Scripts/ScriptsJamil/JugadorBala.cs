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
    public GameObject bulletPrefab;
    public bool PUMorado = false; //esta bugeado el check en el editor, pero sí esta funcionando bn

    void Start()
    {
        rb2dBala = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movimiento();

        //Debug.Log(rb2dBala.velocity.sqrMagnitude);
        //Debug.Log(tiempo);
        //Debug.Log(PUMorado);
    }

    void Movimiento()
    {
        rb2dBala.velocity = direction * rapidez;

        if (PUMorado == false)
        {
            rb2dBala.velocity = direction * rapidez;
            Destroy(gameObject, 2);

        }
        else
        {
            rb2dBala.velocity = direction * rapidez * 3;
            Destroy(gameObject, 2);
            
        }
    }
       
    



}
