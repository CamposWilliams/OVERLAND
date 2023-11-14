using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorMovimiento : MonoBehaviour
{
    Rigidbody2D rb2DMike;
    public float rapidez;
    Vector2 direcci�n;
    //Animator animaci�nMike;

    void Start()
    {
        rb2DMike = GetComponent<Rigidbody2D>();
        //animaci�nMike = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
    }

    void Movimiento()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // Limitar el movimiento a una direcci�n por eje
        if (moveX != 0f)
        {
            moveY = 0f;
        }

        if (moveY != 0f)
        {
            moveX = 0f;
        }

        rb2DMike.velocity = new Vector2(moveX, moveY)*rapidez;



        //direcci�n = new Vector2(xInput, yInput).normalized;

        //animaci�nMike.SetFloat("Horizontal", xInput);
        //animaci�nMike.SetFloat("Vertical", yInput);
        //animaci�nMike.SetFloat("Rapidez",direcci�n.sqrMagnitude);



    }
}
