using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MikeDisparo : MonoBehaviour
{
    public bool balaCreada;
    Rigidbody2D rb2DMike;
    public GameObject[] cajas;

    private void Start()
    {
        rb2DMike = GetComponent<Rigidbody2D>();
    }
    public void DireccionDeLaBala(GameObject balaPrefab, float numeroDeBala)
    {
        if (balaCreada)
        {
            GameObject nuevaBala = Instantiate(balaPrefab);
            nuevaBala.GetComponent<JugadorBala>().numeroDeBala = numeroDeBala;
            //nuevaBala.transform.position = GameObject.Find("PuntoDeDisparo").transform.position;
            //nuevaBala.transform.up = GameObject.Find("Arma").transform.up;

            if (rb2DMike.velocity.x > 0 && Mathf.Abs(rb2DMike.velocity.x) > Mathf.Abs(rb2DMike.velocity.y))
            {
                nuevaBala.transform.position = cajas[1].transform.position;
                nuevaBala.transform.Rotate(Vector3.forward * -90);
               
            }

            else if (rb2DMike.velocity.x < 0 && Mathf.Abs(rb2DMike.velocity.x) > Mathf.Abs(rb2DMike.velocity.y))
            {
                nuevaBala.transform.position = cajas[0].transform.position;
                nuevaBala.transform.Rotate(Vector3.forward * 90);
            }

            else if (rb2DMike.velocity.y < 0 && Mathf.Abs(rb2DMike.velocity.x) < Mathf.Abs(rb2DMike.velocity.y))
            {
                nuevaBala.transform.position = cajas[2].transform.position;
                nuevaBala.transform.Rotate(Vector3.forward * 180);

            }
            else if (rb2DMike.velocity.y > 0 && Mathf.Abs(rb2DMike.velocity.x) < Mathf.Abs(rb2DMike.velocity.y))
            {
                nuevaBala.transform.position = cajas[3].transform.position;
                nuevaBala.transform.Rotate(Vector3.forward * 0);

            }


        }
            balaCreada = false;
        }

    
}
