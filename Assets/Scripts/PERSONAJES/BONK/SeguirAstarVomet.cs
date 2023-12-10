using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SeguirAstarVomet : MonoBehaviour
{

    Animator EnemigoAnimacion;
    private AIPath aiPath;
    public Transform MikeTrf;
    public float valorDelParametroX;
    public float valorDelParametroY;
    public Collider2D enemigoCollider;
    public bool reactivar;
    public bool seHanJuntado;
    public float time;


    void Start()
    {
        aiPath = GetComponent<AIPath>();
        EnemigoAnimacion = GetComponent<Animator>();

    }


    private void Update()
    {

        SeguimientoDeAnimacion();
        AtaqueAnimacion();
       
        ReactivarCollider();

        //Debug.Log(seHanJuntado);
        //Debug.Log(time);

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

        if (collision.gameObject.CompareTag("Enemigo1") && GetComponent<VidaVoment>().saludVoment > 0)
        {
            enemigoCollider.isTrigger = true;
            //reactivar = true;

            
        }

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EscritorioTag") && GetComponent<VidaVoment>().saludVoment > 0)
        {
            enemigoCollider.isTrigger = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && GetComponent<VidaVoment>().saludVoment > 0) 
            {
               enemigoCollider.isTrigger= false;
            }

        if (collision.CompareTag("Enemigo1") && GetComponent<VidaVoment>().saludVoment >0)
        {
            enemigoCollider.isTrigger= true;
            seHanJuntado = true;
             
        }
    }


    void ReactivarCollider()
    {
          
        if (EnemigoAnimacion.GetBool("SeMueve") == false && GetComponent<VidaVoment>().saludVoment >0)
        {
            enemigoCollider.isTrigger = false;
        }

        if(seHanJuntado == true && GetComponent<VidaVoment>().saludVoment > 0)
        {
            time += Time.deltaTime;

            if (time >= 2)
            {
                enemigoCollider.isTrigger = false;
                seHanJuntado =false;
                time = 0;
            }
        }

    }
}
