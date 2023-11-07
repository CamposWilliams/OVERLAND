using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorMovimiento : MonoBehaviour
{
    Rigidbody2D rb2DMike;
    public float rapidez=2;
    public bool PUVerde=false;
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
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");
        
            rb2DMike.velocity = new Vector2(xInput, yInput).normalized * rapidez;
        

       
        //dirección = new Vector2(xInput, yInput).normalized;
       
        //animaciónMike.SetFloat("Horizontal", xInput);
        //animaciónMike.SetFloat("Vertical", yInput);
        //animaciónMike.SetFloat("Rapidez",dirección.sqrMagnitude);

          

    }
}
