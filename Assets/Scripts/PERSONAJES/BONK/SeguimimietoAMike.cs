using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguimimietoAMike : MonoBehaviour
{
  public Rigidbody2D bonkRb2d;
    public Transform MikeTrf;
    Vector2 direccion;
    public float rapidezBonk;
    Animator BonkAnimacion;
    float tiempoDeEspera = 0.4f;
    bool leyendoDatos = true;
    bool estaDentro;
    Vector2 direccion2;
    float valorDelParametroX;
    float valorDelParametroY;

    private void Start()
    {
        bonkRb2d = GetComponent<Rigidbody2D>();
        BonkAnimacion = GetComponent<Animator>();
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
            BonkAnimacion.SetBool("SeMueve", false);

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
            direccion2 = Vector2.zero;
            estaDentro = true;
            BonkAnimacion.SetBool("SeMueve", true);
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
        bonkRb2d.velocity = Vector2.zero;
        
       
            bonkRb2d.velocity = direccion2 * rapidezBonk;
            yield return new WaitForSeconds(tiempoDeEspera);
           
        leyendoDatos = true;

    }

    void SeguimientoDeAnimacion()
    {
        if (estaDentro == true && bonkRb2d.velocity != Vector2.zero)
        {
            if (bonkRb2d.velocity.x > 0)
            {
                //Debug.Log("Derecha");
                BonkAnimacion.SetFloat("ValorY", 0);
                BonkAnimacion.SetFloat("ValorX", 1);
                valorDelParametroX = BonkAnimacion.GetFloat("ValorX");
                valorDelParametroY = BonkAnimacion.GetFloat("ValorY");
            }

            else if (bonkRb2d.velocity.x < 0)
            {
                //Debug.Log("Izquierda");
                BonkAnimacion.SetFloat("ValorY", 0);
                BonkAnimacion.SetFloat("ValorX", -1);
                valorDelParametroX = BonkAnimacion.GetFloat("ValorX");
                valorDelParametroY = BonkAnimacion.GetFloat("ValorY");
            }

            else if (bonkRb2d.velocity.y < 0)
            {
                BonkAnimacion.SetFloat("ValorX", 0);
                BonkAnimacion.SetFloat("ValorY", -1);
                valorDelParametroX = BonkAnimacion.GetFloat("ValorX");
                valorDelParametroY = BonkAnimacion.GetFloat("ValorY");
            }
            else if (bonkRb2d.velocity.y > 0)
            {
                BonkAnimacion.SetFloat("ValorX", 0);
                BonkAnimacion.SetFloat("ValorY", 1);
                valorDelParametroX = BonkAnimacion.GetFloat("ValorX");
                valorDelParametroY = BonkAnimacion.GetFloat("ValorY");
            }

        }

        else
        {
            BonkAnimacion.SetFloat("ValorX", valorDelParametroX);
            BonkAnimacion.SetFloat("ValorY", valorDelParametroY);
        }

    }
}


  

