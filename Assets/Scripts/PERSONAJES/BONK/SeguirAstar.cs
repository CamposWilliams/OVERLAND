using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SeguirAstar : MonoBehaviour
{

    Animator EnemigoAnimacion;
    private AIPath aiPath;
    public Transform MikeTrf;
    float valorDelParametroX;
    float valorDelParametroY;
    public Collider2D enemigoCollider;
    public bool reactivar;
    float time;
    Rigidbody2D enemigoRb2D;


    void Start()
    {
        aiPath = GetComponent<AIPath>();
        EnemigoAnimacion = GetComponent<Animator>();
        //StartCoroutine(VolverTrigger());
        enemigoRb2D = GetComponent<Rigidbody2D>();    
    }


    private void Update()
    {

        SeguimientoDeAnimacion();
        AtaqueAnimacion();
       

        //if (reactivar == true)
        //{
        //    StartCoroutine(ReactivarCollider());
        //}
       



    }

    IEnumerator VolverTrigger()
    {
        while (true)
        {
            if (enemigoRb2D.velocity == Vector2.zero)
            {
                enemigoCollider.isTrigger = true;
                yield return new WaitForSeconds(3);           
                enemigoCollider.isTrigger = false;
            }     
            else
            {
                yield return new WaitForSeconds(1); 
            }

        }
    }

    void AtaqueAnimacion()
    {

    }


    void SeguimientoDeAnimacion()
    {
        if (aiPath.velocity != Vector3.zero)
        {
            EnemigoAnimacion.SetBool("SeMueve", true);

            if (aiPath.velocity.x > 0 && Mathf.Abs(aiPath.velocity.x) > Mathf.Abs(aiPath.velocity.y))
            {
                //Debug.Log("Derecha");
                EnemigoAnimacion.SetFloat("ValorY", 0);
                EnemigoAnimacion.SetFloat("ValorX", 1);
                valorDelParametroX = EnemigoAnimacion.GetFloat("ValorX");
                valorDelParametroY = EnemigoAnimacion.GetFloat("ValorY");
            }

            else if (aiPath.velocity.x < 0 && Mathf.Abs(aiPath.velocity.x) > Mathf.Abs(aiPath.velocity.y))
            {
                //Debug.Log("Izquierda");
                EnemigoAnimacion.SetFloat("ValorY", 0);
                EnemigoAnimacion.SetFloat("ValorX", -1);
                valorDelParametroX = EnemigoAnimacion.GetFloat("ValorX");
                valorDelParametroY = EnemigoAnimacion.GetFloat("ValorY");
            }

            else if (aiPath.velocity.y < 0 && Mathf.Abs(aiPath.velocity.x) < Mathf.Abs(aiPath.velocity.y))
            {
                EnemigoAnimacion.SetFloat("ValorX", 0);
                EnemigoAnimacion.SetFloat("ValorY", -1);
                valorDelParametroX = EnemigoAnimacion.GetFloat("ValorX");
                valorDelParametroY = EnemigoAnimacion.GetFloat("ValorY");
            }
            else if (aiPath.velocity.y > 0 && Mathf.Abs(aiPath.velocity.x) < Mathf.Abs(aiPath.velocity.y))
            {
                EnemigoAnimacion.SetFloat("ValorX", 0);
                EnemigoAnimacion.SetFloat("ValorY", 1);
                valorDelParametroX = EnemigoAnimacion.GetFloat("ValorX");
                valorDelParametroY = EnemigoAnimacion.GetFloat("ValorY");
            }

        }

        else
        {
            EnemigoAnimacion.SetBool("SeMueve", false);
            EnemigoAnimacion.SetFloat("ValorX", valorDelParametroX);
            EnemigoAnimacion.SetFloat("ValorY", valorDelParametroY);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Enemigo1"))
        {
            enemigoCollider.isTrigger = true;
           

            if (EnemigoAnimacion.GetBool("SeMueve") == false)
            {
                enemigoCollider.isTrigger = false;

            }
        }
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EscritorioTag"))
        {
            enemigoCollider.isTrigger = true;
        }
        if (collision.gameObject.CompareTag("Enemigo1"))
        {
            time += Time.deltaTime;
            if (time >= 3)
            {
                enemigoCollider.isTrigger = true;

                if (time >= 5)
                {
                 enemigoCollider.isTrigger = false;
                }
            }
   

            if (EnemigoAnimacion.GetBool("SeMueve") == false)
            {
                enemigoCollider.isTrigger = false;

            }
        }


    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemigoCollider.isTrigger = false;
        }

    }

    //IEnumerator ReactivarCollider()
    //{
    //    yield return null;
    //    if (EnemigoAnimacion.GetBool("SeMueve") == false )
    //    {
    //        enemigoCollider.isTrigger = false;
    //    }

    //}
}
