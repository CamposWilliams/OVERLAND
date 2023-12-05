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


    void Start()
    {
        aiPath = GetComponent<AIPath>();
       EnemigoAnimacion = GetComponent<Animator>();

    }


    private void Update()
    {

        SeguimientoDeAnimacion();
        AtaqueAnimacion();
        if(reactivar==true)
        {
           StartCoroutine(ReactivarCollider());
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
            reactivar = true;
            
                
                if (EnemigoAnimacion.GetBool("SeMueve") == false)
                {
                    Debug.Log("ActivandoCorrutina");
                   

                }        

        }

    }


    IEnumerator ReactivarCollider()
    {
        yield return null;
        if (EnemigoAnimacion.GetBool("SeMueve") == false)
        {
            enemigoCollider.isTrigger = false;
        }
           
    }
}
