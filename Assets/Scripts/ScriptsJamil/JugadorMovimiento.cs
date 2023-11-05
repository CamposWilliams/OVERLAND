using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorMovimiento : MonoBehaviour
{
    Rigidbody2D rb2DMike;
    public float rapidez=2;
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
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");
        direcci�n = new Vector2(xInput, yInput).normalized;
       
        //animaci�nMike.SetFloat("Horizontal", xInput);
        //animaci�nMike.SetFloat("Vertical", yInput);
        //animaci�nMike.SetFloat("Rapidez",direcci�n.sqrMagnitude);

        rb2DMike.velocity = new Vector2(xInput, yInput).normalized * rapidez;   

    }
}
