using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoGordock : MonoBehaviour
{
   
    Rigidbody2D Gordock;
    public Transform MikeTrf;
    Vector2 direccion;
    public float rapidezGordock;
    Animator GordockAnimacion;
    float tiempoDeEspera = 0.4f;
    bool leyendoDatos = true;
    bool estaDentro;
    Vector2 direccion2;
    float valorDelParametroX;
    float valorDelParametroY;

    private void Start()
    {
        Gordock = GetComponent<Rigidbody2D>();
        GordockAnimacion = GetComponent<Animator>();
    }

    private void Update()
    {

        SeguimientoDeAnimacion();
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            estaDentro = false;
            GordockAnimacion.SetBool("estaDentro", false);

            if (leyendoDatos == false)
            {
                Gordock.velocity = Vector2.zero;
            }
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            direccion2 = Vector2.zero;
            estaDentro = true;
            GordockAnimacion.SetBool("estaDentro", true);
            direccion = MikeTrf.position - transform.position;


            if (leyendoDatos == true)
            {
                if (Mathf.Abs(direccion.x) > Mathf.Abs(direccion.y))
                {
                    direccion2 = new Vector2(direccion.x, 0);
                }

                else
                {
                    direccion2 = new Vector2(0, direccion.y);
                }

                leyendoDatos = false;
                StartCoroutine(MantenerVelocidad());
            }

        }

    }
    IEnumerator MantenerVelocidad()
    {
        direccion2.Normalize();
        Gordock.velocity = Vector2.zero;


        Gordock.velocity = direccion2 * rapidezGordock;
        yield return new WaitForSeconds(tiempoDeEspera);

        leyendoDatos = true;

    }

    void SeguimientoDeAnimacion()
    {
        if (estaDentro == true && Gordock.velocity != Vector2.zero)
        {
            if (Gordock.velocity.x > 0)
            {
                //Debug.Log("Derecha");
                GordockAnimacion.SetFloat("ValorY", 0);
                GordockAnimacion.SetFloat("ValorX", 1);
                valorDelParametroX = GordockAnimacion.GetFloat("ValorX");
                valorDelParametroY = GordockAnimacion.GetFloat("ValorY");
            }

            else if (Gordock.velocity.x < 0)
            {
                //Debug.Log("Izquierda");
                GordockAnimacion.SetFloat("ValorY", 0);
                GordockAnimacion.SetFloat("ValorX", -1);
                valorDelParametroX = GordockAnimacion.GetFloat("ValorX");
                valorDelParametroY = GordockAnimacion.GetFloat("ValorY");
            }

            else if (Gordock.velocity.y < 0)
            {
                GordockAnimacion.SetFloat("ValorX", 0);
                GordockAnimacion.SetFloat("ValorY", -1);
                valorDelParametroX = GordockAnimacion.GetFloat("ValorX");
                valorDelParametroY = GordockAnimacion.GetFloat("ValorY");
            }
            else if (Gordock.velocity.y > 0)
            {
                GordockAnimacion.SetFloat("ValorX", 0);
                GordockAnimacion.SetFloat("ValorY", 1);
                valorDelParametroX = GordockAnimacion.GetFloat("ValorX");
                valorDelParametroY = GordockAnimacion.GetFloat("ValorY");
            }

        }

        else
        {
            GordockAnimacion.SetFloat("ValorX", valorDelParametroX);
            GordockAnimacion.SetFloat("ValorY", valorDelParametroY);
        }

    }
}

