using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
        new string tag;
        public GameObject prefabBala;
        GameObject Disfraz;
        public GameObject Mike;
        public bool conPU = false;
        float cd;
        float rapidez=0;
        float rapidezBala;
        SpriteRenderer sprPowerUp;
        Collider2D collPowerUp;
        Animator disfrazAnimator;
        public GameObject sombrita;
        public float contadorAmarillo;
        public float contadorAzul;
        public float contadorMorado;
    private void Awake()
    {
        Mike = GameObject.Find("Mike");
        Disfraz = GameObject.Find("DisfrazPU");
        disfrazAnimator=GameObject.Find("DisfrazPU").GetComponent<Animator>();
    }
    private void Start()
    {
            sprPowerUp = GetComponent<SpriteRenderer>();
            collPowerUp = GetComponent<Collider2D>();
            tag=gameObject.tag;
            //Debug.Log(tag);
        
    }
    private void Update()
    {
        if (disfrazAnimator.GetFloat("PU") != 0 && disfrazAnimator.GetBool("ConPU"))
        {
            Mike.GetComponent<JugadorMovimiento>().conPUA = false;
            Mike.GetComponent<CapsuleCollider2D>().isTrigger = false;
            //Mike.GetComponent<MikeGestorDePU>().AnimacionesPU();
            Mike.GetComponent<JugadorMovimiento>().rapidez = 4;
            //Debug.Log("Hola");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
               
                conPU = true;
                Destroy(sombrita);
             
                switch (tag)
                {
                    case "PocionAzul":

                        Disfraz.GetComponent<ReposicionarPU>().pocionAzul = true;
                        disfrazAnimator.SetBool("ConPU", true);
                        disfrazAnimator.SetFloat("PU", 1);
                        //StartCoroutine(AnimacionesPU());
                        sprPowerUp.enabled = false;
                        collPowerUp.enabled = false;
                        collision.GetComponent<SistemaDeVida>().PUAzulActivo = true;
                  
                    StartCoroutine(DesactivarPowerUpAzul());
                    break;
               
                    case "PocionMorada":
                        disfrazAnimator.SetBool("ConPU", true);
                        disfrazAnimator.SetFloat("PU", 2);
                        //StartCoroutine(AnimacionesPU());
                        sprPowerUp.enabled = false;
                        collPowerUp.enabled = false;
                        cd = Mike.GetComponent<JugadorDisparo>().cdDisparo;
                        Mike.GetComponent<JugadorDisparo>().cdDisparo = cd /3;
                        rapidezBala = prefabBala.GetComponent<JugadorBala>().rapidezBala;
                        prefabBala.GetComponent<JugadorBala>().rapidezBala = rapidezBala * 3;
                   
                    StartCoroutine(DesactivarPowerUpMorado());

                        break;


                    case "PocionAmarilla":
                        Mike.GetComponent<JugadorMovimiento>().conPUA = true;
                        disfrazAnimator.SetBool("ConPU", true);
                        disfrazAnimator.SetFloat("PU", 0);            
                        sprPowerUp.enabled = false;
                        collPowerUp.enabled = false;
                        collision.GetComponent<JugadorMovimiento>().rapidez=4*1.5f;
                    
                    
                    StartCoroutine(DesactivarPowerUpAmarillo());

                    break;
                    
                }

            }
        }

        IEnumerator DesactivarPowerUpMorado()
        {                          
            yield return new WaitForSeconds(20);
            Mike.GetComponent<MikeGestorDePU>().contadorMorado--;

           if (contadorMorado == 0)
           {
                //Mike.GetComponent<MikeGestorDePU>().AnimacionesPU();
                //Debug.Log("Desactivado Morado");
                prefabBala.GetComponent<JugadorBala>().rapidezBala = rapidezBala;
                Mike.GetComponent<JugadorDisparo>().cdDisparo = cd;
                Destroy(gameObject);
           }
                   
               
        }

    IEnumerator DesactivarPowerUpAzul()
    {
        yield return new WaitForSeconds(10);
        Mike.GetComponent<MikeGestorDePU>().contadorAzul--;

        if (Mike.GetComponent<SistemaDeVida>().PUAzulActivo ==true && Mike.GetComponent<MikeGestorDePU>().contadorAzul==0)
        {

                    //Mike.GetComponent<MikeGestorDePU>().AnimacionesPU();
                    Mike.GetComponent<SistemaDeVida>().PUAzulActivo = false;
                    Disfraz.GetComponent<ReposicionarPU>().pocionAzul = false;
                    Destroy(gameObject);      
        }
    }
    
    IEnumerator DesactivarPowerUpAmarillo()
    {
      
       
        yield return new WaitForSeconds(20);
        Mike.GetComponent<MikeGestorDePU>().contadorAmarillo--;
       
        if (Mike.GetComponent<MikeGestorDePU>().contadorAmarillo== 0 )
        {
            Mike.GetComponent<JugadorMovimiento>().conPUA = false;
            Mike.GetComponent<CapsuleCollider2D>().isTrigger = false;
            //Mike.GetComponent<MikeGestorDePU>().AnimacionesPU();
            Mike.GetComponent<JugadorMovimiento>().rapidez = 4;
            //Debug.Log("Hola");
            Destroy(gameObject);
        }
                                
    }

 

}

