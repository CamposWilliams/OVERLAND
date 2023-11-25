using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class CambiarDireccionArmaBalaYAnimacion : MonoBehaviour
{
    public GameObject puntoDeDisparo;
    public Camera cam;
    public float angulo;
    bool colisionaConObjetos;
    private Animator direcci�nMirada;
    public GameObject arma;
     public GameObject balaPrefabPistola;
    public GameObject balaPrefabRifle;
    public GameObject balaPrefabMisil;
    public GameObject balaPrefabEspcial;

    public Vector2 Direction;
    Rigidbody2D MikeRb2D;
    public GameObject[] cuchilloCajasColliders;
    float anguloConstante;
    public SpriteRenderer armaSpr;
    Quaternion rotacionActual;


    private void Start()
    { 
       MikeRb2D= GetComponent<Rigidbody2D>();
       direcci�nMirada = GetComponent<Animator>();
       StartCoroutine(DireccionDelArma());
       StartCoroutine(DireccionAnimacion());
       
    }


   IEnumerator DireccionAnimacion()
    {
        while(true)
        {
            if (colisionaConObjetos == false && MikeRb2D.velocity.magnitude != 0)
            {
                direcci�nMirada.SetFloat("Rapidez", 100);
            }

            else
            {
                direcci�nMirada.SetFloat("Rapidez", 0);
            }
            direcci�nMirada.SetFloat("Angulo", anguloConstante);
            yield return new WaitForSeconds(0.15f);

        }


    }

      IEnumerator DireccionDelArma( )
    {      
        while(true)
        {
            Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

            Direction = mousePosition - arma.transform.position;

            arma.transform.up = Direction.normalized;
            arma.transform.Rotate(Vector3.forward * 90.0f);
            angulo = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;
            //

            balaPrefabPistola.GetComponent<JugadorBala>().direction = Direction.normalized;
            balaPrefabRifle.GetComponent<JugadorBala>().direction = Direction.normalized;
            balaPrefabMisil.GetComponent<JugadorBala>().direction = Direction.normalized;
            balaPrefabEspcial.GetComponent<JugadorBala>().direction = Direction.normalized;

            //

            //Este devuelve un valor de -180 a 180
            if (angulo < 0)
            {
                angulo += 360;
            }

            if (angulo < 45 || angulo >= 315)
            {

                anguloConstante = 0;
            }

            else if (angulo > 45 && angulo < 135)
            {
                anguloConstante = 90;
            }

            else if (angulo > 135 && angulo < 225)
            {
                anguloConstante = 180;
            }

            else if (angulo > 225 && angulo < 315)
            {
                anguloConstante = 270;
            }
           
            arma.transform.rotation = rotacionActual;

            armaSpr.enabled=true;

            switch (anguloConstante)
            {
                case 0: arma.transform.position = cuchilloCajasColliders[0].transform.position; 
                   
                    break;
               
                case 90: arma.transform.position = cuchilloCajasColliders[1].transform.position;
                         armaSpr.enabled = false;
                        arma.transform.rotation= rotacionActual;
                        arma.transform.Rotate(Vector3.forward*90);


                    break;
                case 180: arma.transform.position = cuchilloCajasColliders[2].transform.position;
                          
                    
                    rotacionActual = arma.transform.rotation;
                 
                    Quaternion nuevaRotacion = rotacionActual * Quaternion.Euler(0, 180, 0);

                    arma.transform.rotation = nuevaRotacion;

                    break;
                case 270: arma.transform.position = cuchilloCajasColliders[3].transform.position;
                    arma.transform.rotation = rotacionActual;
                    arma.transform.Rotate(-Vector3.forward*90);

                    break;
            }
            yield return new WaitForSeconds(0.15f);
            
        }
           
     
    }

    public void DireccionDeLaBala(GameObject balaPrefab)
    {

        balaPrefab.transform.position = GameObject.Find("PuntoDeDisparo").transform.position;
        balaPrefab.transform.up = GameObject.Find("Arma").transform.up;
        balaPrefab.transform.Rotate(Vector3.forward * 90.0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Enemigo1"))
        {
            Debug.Log("Choque");
            colisionaConObjetos = true;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        colisionaConObjetos = false;
    }
}