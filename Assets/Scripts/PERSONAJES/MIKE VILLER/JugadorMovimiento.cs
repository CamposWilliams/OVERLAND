using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorMovimiento : MonoBehaviour
{
    Rigidbody2D rb2DMike;
    public float rapidez;
    Vector2 direcci�n;
    bool colisionaConPared;
    Animator animaci�nMike;
    private Vector3 mousePosAnterior;
    public bool mouseMovido;
    public float moveX;
    public float moveY;
    public bool retrocediendo;

    void Start()
    {
        rb2DMike = GetComponent<Rigidbody2D>();
        animaci�nMike = GetComponent<Animator>();
    }

    void Update()
    {
        if (retrocediendo==false)
        {
            Movimiento();

        }
    }

    void Movimiento()
    {    
            
            moveX = Input.GetAxisRaw("Horizontal");
            moveY = Input.GetAxisRaw("Vertical");


            if (moveX != 0f)
            {
                moveY = 0f;
            }

            if (moveY != 0f)
            {
                moveX = 0f;
            }

            direcci�n = new Vector2(moveX, moveY).normalized;
            rb2DMike.velocity = direcci�n * rapidez;

    }

    
}
