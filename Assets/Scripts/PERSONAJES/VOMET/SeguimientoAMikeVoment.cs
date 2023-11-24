using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguimimietoAMikeVoment : MonoBehaviour
{
    public Rigidbody2D VomentRb2d;
    public Transform MikeTrf;
    Vector2 direccion;
    public float rapidezBonk;
    Animator VomentAnimacion;
    float tiempoDeEspera = 0.4f;
    bool leyendoDatos = true;
    bool estaDentro;
    Vector2 direccion2;
    float valorDelParametroX;
    float valorDelParametroY;

    private void Start()
    {
        VomentRb2d = GetComponent<Rigidbody2D>();
        VomentAnimacion = GetComponent<Animator>();
    }

    private void Update()
    {

        SeguimientoDeAnimacion();
        //Debug.Log(Gordock.velocity);
        //CorreccionDeSeguimiento();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            estaDentro = false;
            VomentAnimacion.SetBool("estaDentro", false);

            if (leyendoDatos == false)
            {
                VomentRb2d.velocity = Vector2.zero;
            }
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            direccion2 = Vector2.zero;
            estaDentro = true;
            VomentAnimacion.SetBool("estaDentro", true);
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
        VomentRb2d.velocity = Vector2.zero;


        VomentRb2d.velocity = direccion2 * rapidezBonk;
        yield return new WaitForSeconds(tiempoDeEspera);

        leyendoDatos = true;

    }

    void SeguimientoDeAnimacion()
    {
        if (estaDentro == true && VomentRb2d.velocity != Vector2.zero)
        {
            if (VomentRb2d.velocity.x > 0)
            {
                //Debug.Log("Derecha");
                VomentAnimacion.SetFloat("ValorY", 0);
                VomentAnimacion.SetFloat("ValorX", 1);
                valorDelParametroX = VomentAnimacion.GetFloat("ValorX");
                valorDelParametroY = VomentAnimacion.GetFloat("ValorY");
            }

            else if (VomentRb2d.velocity.x < 0)
            {
                //Debug.Log("Izquierda");
                VomentAnimacion.SetFloat("ValorY", 0);
                VomentAnimacion.SetFloat("ValorX", -1);
                valorDelParametroX = VomentAnimacion.GetFloat("ValorX");
                valorDelParametroY = VomentAnimacion.GetFloat("ValorY");
            }

            else if (VomentRb2d.velocity.y < 0)
            {
                VomentAnimacion.SetFloat("ValorX", 0);
                VomentAnimacion.SetFloat("ValorY", -1);
                valorDelParametroX = VomentAnimacion.GetFloat("ValorX");
                valorDelParametroY = VomentAnimacion.GetFloat("ValorY");
            }
            else if (VomentRb2d.velocity.y > 0)
            {
                VomentAnimacion.SetFloat("ValorX", 0);
                VomentAnimacion.SetFloat("ValorY", 1);
                valorDelParametroX = VomentAnimacion.GetFloat("ValorX");
                valorDelParametroY = VomentAnimacion.GetFloat("ValorY");
            }

        }

        else
        {
            VomentAnimacion.SetFloat("ValorX", valorDelParametroX);
            VomentAnimacion.SetFloat("ValorY", valorDelParametroY);
        }

    }
}

