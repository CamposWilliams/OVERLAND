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

    private void Awake()
    {
        rapidezBala = 10; 
    }
    void Start()
    {
        velocidadMike=GameObject.Find("Mike").GetComponent<Rigidbody2D>().velocity;
        rb2dBala = GetComponent<Rigidbody2D>();
        
          
    }

    void Update()
    {
        Movimiento();
  
    }
  
    void Movimiento()
    {
        rb2dBala.velocity = rapidezBala * direction + 0.5f*velocidadMike;

        Destroy(gameObject, 2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("TileCollider"))
        {
            Destroy(gameObject);
        }
       
    }

   
}
