using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguimimietoAMike : MonoBehaviour
{
    Rigidbody2D bonkRb2d;
    public Transform MikeTrf;
    Vector2 direccion;
    public float rapidezBonk;
    Animator BonkAnimacion;
    float angulo=0;
    float temporizador;
    float tiempoDeEspera=0.6f;
    bool leyendoDatos=true;
    bool estaDentro;


    private void Start()
    {
        bonkRb2d = GetComponent<Rigidbody2D>();
        BonkAnimacion = GetComponent<Animator>();
    }

    private void Update()
    {
        SeguimientoDeAnimacion();
        //CorreccionDeSeguimiento();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            estaDentro = false;
            BonkAnimacion.SetFloat("Rapidez", 100);
            if (leyendoDatos == false)
            {
                bonkRb2d.velocity = Vector2.zero;
            }
        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            estaDentro = true;
            BonkAnimacion.SetFloat("Rapidez", 0);
            direccion = MikeTrf.position - transform.position;
            direccion.Normalize();
            
            if (leyendoDatos==true)
            {
                if (Mathf.Abs(direccion.x) > Mathf.Abs(direccion.y))
                {
                    direccion.y = 0;
                }

                else
                {
                    direccion.x = 0;
                }
                
                leyendoDatos = false;
                StartCoroutine(MantenerVelocidad());
            }          
            
        }
        else
        {
            if (estaDentro==false)
            {
                BonkAnimacion.SetFloat("Rapidez", 100);
            }
            
        }
        
    }
    IEnumerator MantenerVelocidad()
    {
        bonkRb2d.velocity = Vector2.zero;
        bonkRb2d.velocity = direccion * rapidezBonk;

        yield return new WaitForSeconds(tiempoDeEspera);
        leyendoDatos = true;
       
    }

    void SeguimientoDeAnimacion()
    {
        if (estaDentro == false || leyendoDatos == true)
        {
            direccion = MikeTrf.position - transform.position;
            angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;
            //Este devuelve un valor de -180 a 180

            if (angulo < 0)
            {
                angulo += 360;

                if (angulo >= 315)
                {
                    angulo = 0;
                }
            }

            BonkAnimacion.SetFloat("Angulo", angulo);
        }
    }

    //void CorreccionDeSeguimiento()
    //{
    //    if(bonkRb2d.velocity.x<=0 )
    //    {
    //        BonkAnimacion.SetFloat("Angulo", 180);
    //    }
    //}
}
