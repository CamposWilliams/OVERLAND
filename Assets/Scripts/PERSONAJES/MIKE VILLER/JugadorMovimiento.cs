using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorMovimiento : MonoBehaviour
{
    Rigidbody2D rb2DMike;
    public float rapidez;
    Vector2 dirección;
    //Animator animaciónMike;

    void Start()
    {
        rb2DMike = GetComponent<Rigidbody2D>();
        //animaciónMike = GetComponent<Animator>();   
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

        // Limitar el movimiento a una dirección por eje
        if (moveX != 0f)
        {
            moveY = 0f;
        }

        if (moveY != 0f)
        {
            moveX = 0f;
        }

        rb2DMike.velocity = new Vector2(moveX, moveY)*rapidez;



        //dirección = new Vector2(xInput, yInput).normalized;

        //animaciónMike.SetFloat("Horizontal", xInput);
        //animaciónMike.SetFloat("Vertical", yInput);
        //animaciónMike.SetFloat("Rapidez",dirección.sqrMagnitude);



    }
}
