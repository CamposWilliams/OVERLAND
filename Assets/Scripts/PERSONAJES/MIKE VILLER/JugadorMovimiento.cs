using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorMovimiento : MonoBehaviour
{
    Rigidbody2D rb2DMike;
    public float rapidez;
    Vector2 dirección;
    bool colisionaConPared;
    Animator animaciónMike;
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
        animaciónMike = GetComponent<Animator>();
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

            dirección = new Vector2(moveX, moveY).normalized;
            rb2DMike.velocity = dirección * rapidez;

    }

    void MovimientoAnimacion()
    {
       
        if (rb2DMike.velocity != Vector2.zero)
        {
            animaciónMike.SetBool("SeMueve", true);
            animaciónMike.SetBool("ExcedeTiempo", false);
            if (anguloMikeDisparo ==0)
            {
                //Debug.Log("Derecha");
                animaciónMike.SetFloat("ValorY", 0);
                animaciónMike.SetFloat("ValorX", 1);
                valorDelParametroX = animaciónMike.GetFloat("ValorX");
                valorDelParametroY = animaciónMike.GetFloat("ValorY");
            }

            else if (anguloMikeDisparo == 180)
            {
                //Debug.Log("Izquierda");
                animaciónMike.SetFloat("ValorY", 0);
                animaciónMike.SetFloat("ValorX", -1);
                valorDelParametroX = animaciónMike.GetFloat("ValorX");
                valorDelParametroY = animaciónMike.GetFloat("ValorY");
            }

            else if (anguloMikeDisparo == 270)
            {
                animaciónMike.SetFloat("ValorX", 0);
                animaciónMike.SetFloat("ValorY", -1);
                valorDelParametroX = animaciónMike.GetFloat("ValorX");
                valorDelParametroY = animaciónMike.GetFloat("ValorY");
            }
            else if (anguloMikeDisparo == 90)
            {
                animaciónMike.SetFloat("ValorX", 0);
                animaciónMike.SetFloat("ValorY", 1);
                valorDelParametroX = animaciónMike.GetFloat("ValorX");
                valorDelParametroY = animaciónMike.GetFloat("ValorY");
            }

        }

        else
        {
            animaciónMike.SetBool("SeMueve", false);
            animaciónMike.SetFloat("ValorX", valorDelParametroX);
            animaciónMike.SetFloat("ValorY", valorDelParametroY);
            
            if (anguloMikeDisparo == 0)
            {
                
                //Debug.Log("Derecha");
                animaciónMike.SetFloat("ValorY", 0);
                animaciónMike.SetFloat("ValorX", 1);
                valorDelParametroX = animaciónMike.GetFloat("ValorX");
                valorDelParametroY = animaciónMike.GetFloat("ValorY");
                time += Time.deltaTime;
            }

            else if (anguloMikeDisparo == 180)
            {
                
                //Debug.Log("Izquierda");
                animaciónMike.SetFloat("ValorY", 0);
                animaciónMike.SetFloat("ValorX", -1);
                valorDelParametroX = animaciónMike.GetFloat("ValorX");
                valorDelParametroY = animaciónMike.GetFloat("ValorY");
                time += Time.deltaTime;
            }

            else if (anguloMikeDisparo == 270)
            {
               
                animaciónMike.SetFloat("ValorX", 0);
                animaciónMike.SetFloat("ValorY", -1);
                valorDelParametroX = animaciónMike.GetFloat("ValorX");
                valorDelParametroY = animaciónMike.GetFloat("ValorY");
                time += Time.deltaTime;
            }
            else if (anguloMikeDisparo == 90)
            {
              
                animaciónMike.SetFloat("ValorX", 0);
                animaciónMike.SetFloat("ValorY", 1);
                valorDelParametroX = animaciónMike.GetFloat("ValorX");
                valorDelParametroY = animaciónMike.GetFloat("ValorY");
                time += Time.deltaTime;
            }
           
            if (time >= timer && animaciónMike.GetBool("ExcedeTimepo")==false)
            {                          
                StartCoroutine("AnimacionIddle");
               
            }
        }

    }

    IEnumerator AnimacionIddle()
    {
        
       
        animaciónMike.SetBool("ExcedeTiempo", true);
        yield return new WaitForSeconds(2);
        animaciónMike.SetBool("ExcedeTiempo", false);
        time = 0;

         
    }
}
