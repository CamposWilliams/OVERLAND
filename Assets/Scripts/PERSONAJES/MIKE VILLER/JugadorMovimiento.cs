using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorMovimiento : MonoBehaviour
{
    Rigidbody2D rb2DMike;
    public float rapidez=4;
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
    float time2;
    bool muere;
    float anguloMikeDisparo;
    public bool conPUA;
    bool vuelve;
    float contador;
    void Start()
    {
        rb2DMike = GetComponent<Rigidbody2D>();
        animaciónMike = GetComponent<Animator>();
    }

    void Update()
    {
        anguloMikeDisparo = GetComponent<MikeDisparo>().anguloConstante;
        muere = GetComponent<SistemaDeVida>().sinVida;
        if (muere == false)
        {
            if (retrocediendo == false)
            {
                Movimiento();
                MovimientoAnimacion();
                EjecutarIddle();

                // Verificar si el mouse se ha movido
                if (Input.mousePosition != mousePosAnterior)
                {
                    // El mouse se ha movido, restablecer el tiempo
                    time = 0f;
                    animaciónMike.SetBool("Volviendo", true);
                }

                // Actualizar la posición del mouse para la próxima verificación
                mousePosAnterior = Input.mousePosition;
            }
        }
    }

    void EjecutarIddle()
    {
        time += Time.deltaTime;
        Debug.Log(time);
       
        if(!animaciónMike.GetBool("SeMueve") && time >= 5)
        {
            if (contador == 0)
            {
                animaciónMike.SetBool("Volviendo", false);
                animaciónMike.SetTrigger("ExcedeTiempo");
                contador++;
            }
           
            
            if (time >= 7 /*&& contador==1*/)
            {
                animaciónMike.SetBool("Volviendo", true);
                vuelve = true;
                contador = 0;
                time = 0;
               
            }
                       

        }
        else if (animaciónMike.GetBool("SeMueve"))
        {
            animaciónMike.SetBool("Volviendo", true);
            time = 0;
        }

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if ((collision.gameObject.CompareTag("Enemigo1") && conPUA) && !colisionaConPared)
        {
           GetComponent<CapsuleCollider2D>().isTrigger = true;
        }

        if (collision.gameObject.CompareTag("TileCollider"))
        {
            colisionaConPared = true;
        }
        
       
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("TileCollider"))
        {
            colisionaConPared = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemigo1"))
        {
            GetComponent<CapsuleCollider2D>().isTrigger = false;
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
    }


}
