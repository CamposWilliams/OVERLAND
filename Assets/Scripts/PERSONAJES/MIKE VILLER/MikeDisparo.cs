using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MikeDisparo : MonoBehaviour
{
    public bool balaCreada;
    Rigidbody2D rb2DMike;
    public GameObject[] cajas;
    public Camera cam;
    float angulo;
    public float anguloConstante;
    Vector2 Direction;
    public GameObject balaPrefab;
   public Vector2 referencia;

    private void Start()
    {
       
        rb2DMike = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        DireccionDelArma();
    }
    void  DireccionDelArma()
    {
       
            Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

            Direction = mousePosition - transform.position;

            angulo = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;

            //Este devuelve un valor de -180 a 180
            if (angulo < 0)
            {
                angulo += 360;
            }

            if (angulo < 45 || angulo >= 315)
            {

                anguloConstante = 0;
            }

            else if (angulo > 45 && angulo < 135)
            {
                anguloConstante = 90;
            }

            else if (angulo > 135 && angulo < 225)
            {
                anguloConstante = 180;
            }

            else if (angulo > 225 && angulo < 315)
            {
                anguloConstante = 270;
            }

            //arma.transform.rotation = rotacionActual;


        
    }


    public void DireccionDeLaBala(GameObject balaPrefab, float numeroDeBala)
    {
        if (balaCreada)
        {
            GameObject nuevaBala = Instantiate(balaPrefab);
            nuevaBala.GetComponent<JugadorBala>().numeroDeBala = numeroDeBala;
            //nuevaBala.transform.position = GameObject.Find("PuntoDeDisparo").transform.position;
            //nuevaBala.transform.up = GameObject.Find("Arma").transform.up;

            if (anguloConstante==0)
            {
                nuevaBala.transform.position = cajas[0].transform.position;
                nuevaBala.transform.Rotate(Vector3.forward * -90);
                referencia = Vector2.right;
                
                              
            }

            else if (anguloConstante == 180)
            {
                nuevaBala.transform.position = cajas[2].transform.position;
                nuevaBala.transform.Rotate(Vector3.forward * 90);
                referencia = Vector2.left;


            }

            else if (anguloConstante == 270)
            {
                nuevaBala.transform.position = cajas[3].transform.position;
                nuevaBala.transform.Rotate(Vector3.forward * 180);
                referencia = Vector2.down;


            }
            else if (anguloConstante == 90)
            {
                nuevaBala.transform.position = cajas[1].transform.position;
                nuevaBala.transform.Rotate(Vector3.forward * 0);
                referencia = Vector2.up;

            }

            //else
            //{
            //    nuevaBala.transform.position = cajas[1].transform.position;
            //    nuevaBala.transform.Rotate(Vector3.forward * 0);
            //}

        }
           
        balaCreada = false;
    }

    
}
