using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.UIElements;

public class JugadorBala : MonoBehaviour
{
    public float rapidezBala;
    Vector2 velocidadMike;
    Rigidbody2D rb2dBala;
    public Vector2 direction;
    Animator animacionBala;
   public float numeroDeBala;
   

    private void Awake()
    {
        rapidezBala = 10;
       
    }
    void Start()
    {
        animacionBala = GetComponent<Animator>();
        velocidadMike =GameObject.Find("Mike").GetComponent<Rigidbody2D>().velocity;
        rb2dBala = GetComponent<Rigidbody2D>();
        direction = GameObject.Find("Mike").GetComponent<CambiarDireccionArmaBalaYAnimacion>().Direction.normalized;
        
        
          
    }

    void Update()
    {
        Movimiento();
        ReproducirAnimacionDelTipoDeBala();
        Debug.Log(numeroDeBala);
    }

    void Movimiento()
    {
        rb2dBala.velocity = rapidezBala * direction + 0.5f*velocidadMike;

        Destroy(gameObject, 1);
    }
    void ReproducirAnimacionDelTipoDeBala()
    {
        
            animacionBala.SetFloat("TipoDeBala", numeroDeBala);      
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("TileCollider"))
        {
            Destroy(gameObject);
        }
       
    }

   
}
