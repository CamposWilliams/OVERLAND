using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorMovimiento : MonoBehaviour
{
    Rigidbody2D rb2DMike;
    public float rapidez;
    Vector2 direcci�n;
    bool colisionaConPared;
    Animator animaci�nMike;
    private Vector3 mousePosAnterior;
    public bool mouseMovido;
    public float moveX;
    public float moveY;
    public bool retrocediendo;
    float valorDelParametroX;
    float valorDelParametroY;
    float timer=5;
    float time;
    bool muere;
    float anguloMikeDisparo;

    void Start()
    {
        rb2DMike = GetComponent<Rigidbody2D>();
        animaci�nMike = GetComponent<Animator>();
    }

    void Update()
        
    {
        anguloMikeDisparo = GetComponent<MikeDisparo>().anguloConstante;
        muere = GetComponent<SistemaDeVida>().sinVida;
        if (muere==false)
        {
            if (retrocediendo == false)
            {
                Movimiento();
                MovimientoAnimacion();

            }
        }
      
    }

    void Movimiento()
    {    
            
            moveX = Input.GetAxisRaw("Horizontal");
            moveY = Input.GetAxisRaw("Vertical");


            if (moveX != 0f)
            {
                moveY = 0f;
            }

            if (moveY != 0f)
            {
                moveX = 0f;
            }

            direcci�n = new Vector2(moveX, moveY).normalized;
            rb2DMike.velocity = direcci�n * rapidez;

    }

    void MovimientoAnimacion()
    {
       
        if (rb2DMike.velocity != Vector2.zero)
        {
            animaci�nMike.SetBool("SeMueve", true);
            animaci�nMike.SetBool("ExcedeTiempo", false);
            if (anguloMikeDisparo ==0)
            {
                //Debug.Log("Derecha");
                animaci�nMike.SetFloat("ValorY", 0);
                animaci�nMike.SetFloat("ValorX", 1);
                valorDelParametroX = animaci�nMike.GetFloat("ValorX");
                valorDelParametroY = animaci�nMike.GetFloat("ValorY");
            }

            else if (anguloMikeDisparo == 180)
            {
                //Debug.Log("Izquierda");
                animaci�nMike.SetFloat("ValorY", 0);
                animaci�nMike.SetFloat("ValorX", -1);
                valorDelParametroX = animaci�nMike.GetFloat("ValorX");
                valorDelParametroY = animaci�nMike.GetFloat("ValorY");
            }

            else if (anguloMikeDisparo == 270)
            {
                animaci�nMike.SetFloat("ValorX", 0);
                animaci�nMike.SetFloat("ValorY", -1);
                valorDelParametroX = animaci�nMike.GetFloat("ValorX");
                valorDelParametroY = animaci�nMike.GetFloat("ValorY");
            }
            else if (anguloMikeDisparo == 90)
            {
                animaci�nMike.SetFloat("ValorX", 0);
                animaci�nMike.SetFloat("ValorY", 1);
                valorDelParametroX = animaci�nMike.GetFloat("ValorX");
                valorDelParametroY = animaci�nMike.GetFloat("ValorY");
            }

        }

        else
        {
            animaci�nMike.SetBool("SeMueve", false);
            animaci�nMike.SetFloat("ValorX", valorDelParametroX);
            animaci�nMike.SetFloat("ValorY", valorDelParametroY);
            
            if (anguloMikeDisparo == 0)
            {
                
                //Debug.Log("Derecha");
                animaci�nMike.SetFloat("ValorY", 0);
                animaci�nMike.SetFloat("ValorX", 1);
                valorDelParametroX = animaci�nMike.GetFloat("ValorX");
                valorDelParametroY = animaci�nMike.GetFloat("ValorY");
                time += Time.deltaTime;
            }

            else if (anguloMikeDisparo == 180)
            {
                
                //Debug.Log("Izquierda");
                animaci�nMike.SetFloat("ValorY", 0);
                animaci�nMike.SetFloat("ValorX", -1);
                valorDelParametroX = animaci�nMike.GetFloat("ValorX");
                valorDelParametroY = animaci�nMike.GetFloat("ValorY");
                time += Time.deltaTime;
            }

            else if (anguloMikeDisparo == 270)
            {
               
                animaci�nMike.SetFloat("ValorX", 0);
                animaci�nMike.SetFloat("ValorY", -1);
                valorDelParametroX = animaci�nMike.GetFloat("ValorX");
                valorDelParametroY = animaci�nMike.GetFloat("ValorY");
                time += Time.deltaTime;
            }
            else if (anguloMikeDisparo == 90)
            {
              
                animaci�nMike.SetFloat("ValorX", 0);
                animaci�nMike.SetFloat("ValorY", 1);
                valorDelParametroX = animaci�nMike.GetFloat("ValorX");
                valorDelParametroY = animaci�nMike.GetFloat("ValorY");
                time += Time.deltaTime;
            }
           
            if (time >= timer && animaci�nMike.GetBool("ExcedeTimepo")==false)
            {                          
                StartCoroutine("AnimacionIddle");
               
            }
        }

    }

    IEnumerator AnimacionIddle()
    {
        
       
        animaci�nMike.SetBool("ExcedeTiempo", true);
        yield return new WaitForSeconds(2);
        animaci�nMike.SetBool("ExcedeTiempo", false);
        time = 0;

         
    }
}
