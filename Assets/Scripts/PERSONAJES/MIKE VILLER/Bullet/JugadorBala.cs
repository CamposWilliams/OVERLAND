using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class JugadorBala : MonoBehaviour
{
    public float rapidezBala;
    Vector2 velocidadMike;
    Rigidbody2D rb2dBala;
    public Vector2 direction;
    public GameObject bulletPrefab;

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

        //Debug.Log(rb2dBala.velocity.sqrMagnitude);
        //Debug.Log(tiempo);
        //Debug.Log(PUMorado);
    }

    void Movimiento()
    {
        rb2dBala.velocity = rapidezBala * direction + velocidadMike;

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
