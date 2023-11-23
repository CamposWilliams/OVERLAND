using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retroceso : MonoBehaviour
{
 
    public GameObject Mike;
    Rigidbody2D MikeRb2D;
    Vector2 velocidadChoque;
    void Start()
    {
        MikeRb2D = GetComponent<Rigidbody2D>();
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo1"))
        {
            velocidadChoque = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
            StartCoroutine(VolverActivarMovimiento());

        }
    }

    IEnumerator VolverActivarMovimiento()
    {
        Mike.GetComponent<JugadorMovimiento>().retrocediendo = true;

        Debug.Log("ENEMIGO");
        if (velocidadChoque.x > 0)
        {
            MikeRb2D.AddForce(Vector2.right * 3, ForceMode2D.Impulse);
        }
        else if (velocidadChoque.x < 0)
        {
            MikeRb2D.AddForce(Vector2.left * 3, ForceMode2D.Impulse);
        }
        else if (velocidadChoque.y > 0)
        {
            MikeRb2D.AddForce(Vector2.up * 3, ForceMode2D.Impulse);
        }
        else if (velocidadChoque.y < 0)
        {
            MikeRb2D.AddForce(-Vector2.up * 3, ForceMode2D.Impulse);
        }
        yield return new WaitForSeconds(1);
        Mike.GetComponent<JugadorMovimiento>().retrocediendo = false;

    }
}
