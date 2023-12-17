using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class DañoGordock : MonoBehaviour
{
    public AIPath aiPath;
    float dañoPorGolpe = 3;
    float time1;
    float time2;
    public float tiempoParaVolverADisparar= 1.7f;
    float cadenciaDeTiro=0.85f;
    Animator GordockAnimator;
    bool disparando;
    public GameObject balaGordock;
    public GameObject balaGordock2;
    float contador;
    bool puedeDisparar=true;
    float contador2;
    public float contador3;
    bool dañoContinuo;
    GameObject Mike;

    private void Awake()
    {
        tiempoParaVolverADisparar =2.1f;
        Mike = GameObject.Find("Mike");
    }
    private void Start()
    {
        GordockAnimator = GetComponent<Animator>();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !Mike.GetComponent<JugadorMovimiento>().conPUA)
        {
            dañoContinuo = true;   
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !Mike.GetComponent<JugadorMovimiento>().conPUA)
        {
            time2 = 0;
            dañoContinuo = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            disparando = true;
           
            //if (Mike.GetComponent<JugadorMovimiento>().conPUA)
            //{
            //    //Debug.Log("Entre");
            //    dañoContinuo = true;
            //}
            
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            disparando = false;
            dañoContinuo = false;
            time2 = 0;
            //if (Mike.GetComponent<JugadorMovimiento>().conPUA)
            //{
            //    dañoContinuo = false;
            //    time2 = 0;
            //}       


        }
        
    }
    private void Update()
    {
        if (aiPath.enabled)
        {
            if (GetComponent<VidaGordock>().muriendo == false)
            {
                //Debug.Log(time1);
                DispararGordock();
                ReactivarAnimacionYBala();
            }
        }
       
        DañoContinuoPorChoque();

    }

    void DañoContinuoPorChoque()
    {
        if (dañoContinuo)
        {
            time2 += Time.deltaTime;
            if (time2 >= 0.6f)
            {
                Debug.Log("DañoGordock");
                Mike.GetComponent<SistemaDeVida>().BajarVida(dañoPorGolpe);
                time2 = 0;
            }
        }
        
         
        
    }
    void DispararGordock()
    {
        if (disparando)
        {

            if (puedeDisparar)
            {
                aiPath.maxSpeed = 0;
                GordockAnimator.SetBool("SeMueve", false);
                GordockAnimator.SetBool("Disparando", true);
                //GameObject nuevaBala = Instantiate(balaGordock);
                //nuevaBala.transform.position = transform.position;
                //nuevaBala.GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<SeguirAstar>().valorDelParametroX, GetComponent<SeguirAstar>().valorDelParametroY) * 5;
                contador++;
                puedeDisparar = false;
               

            }
            
        }
        
    }

    void ReactivarAnimacionYBala()
    {

        if (!puedeDisparar)
        {
            time1 += Time.deltaTime;

            if ((time1 >= cadenciaDeTiro && time1 < tiempoParaVolverADisparar) && contador == 1)
            {

                //GordockAnimator.SetBool("SeMueve", false);
                //GordockAnimator.SetBool("Disparando", true);
                if (contador3 % 2==0)
                {
                   
                    if (aiPath.velocity.x > 0 && Mathf.Abs(aiPath.velocity.x) > Mathf.Abs(aiPath.velocity.y))
                    {
                        GameObject nuevaBala = Instantiate(balaGordock);
                        nuevaBala.GetComponent<BalaGordock>().contadorGordock=contador3;
                        nuevaBala.transform.position = transform.position;
                        nuevaBala.GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<SeguirAstarGordock>().valorDelParametroX, GetComponent<SeguirAstarGordock>().valorDelParametroY) * 5;
                        nuevaBala.transform.up = new Vector2(GetComponent<SeguirAstarGordock>().valorDelParametroX, GetComponent<SeguirAstarGordock>().valorDelParametroY);
                        nuevaBala.transform.Rotate(Vector3.forward * -90);
                        Destroy(nuevaBala, 1);
                        if (contador2 == 0)
                        {
                            Destroy(nuevaBala);
                        }
                        contador2++;
                        contador = 0;
                    }

                    else if (aiPath.velocity.x < 0 && Mathf.Abs(aiPath.velocity.x) > Mathf.Abs(aiPath.velocity.y))
                    {
                        GameObject nuevaBala = Instantiate(balaGordock);
                        nuevaBala.GetComponent<BalaGordock>().contadorGordock = contador3;
                        nuevaBala.transform.position = transform.position;
                        nuevaBala.GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<SeguirAstarGordock>().valorDelParametroX, GetComponent<SeguirAstarGordock>().valorDelParametroY) * 5;
                        nuevaBala.transform.up = new Vector2(GetComponent<SeguirAstarGordock>().valorDelParametroX, GetComponent<SeguirAstarGordock>().valorDelParametroY);
                        nuevaBala.transform.Rotate(Vector3.forward * 90);
                        Destroy(nuevaBala, 1);
                        if (contador2 == 0)
                        {
                            Destroy(nuevaBala);
                        }
                        contador2++;
                        contador = 0;
                    }

                    else if (aiPath.velocity.y < 0 && Mathf.Abs(aiPath.velocity.x) < Mathf.Abs(aiPath.velocity.y))
                    {
                        GameObject nuevaBala = Instantiate(balaGordock);
                        nuevaBala.GetComponent<BalaGordock>().contadorGordock = contador3;
                        nuevaBala.transform.position = transform.position;
                        nuevaBala.GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<SeguirAstarGordock>().valorDelParametroX, GetComponent<SeguirAstarGordock>().valorDelParametroY) * 5;
                        nuevaBala.transform.up = new Vector2(GetComponent<SeguirAstarGordock>().valorDelParametroX, GetComponent<SeguirAstarGordock>().valorDelParametroY);
                        nuevaBala.transform.Rotate(Vector3.forward * 90);
                        Destroy(nuevaBala, 1);
                        if (contador2 == 0)
                        {
                            Destroy(nuevaBala);
                        }
                        contador2++;
                        contador = 0;
                    }
                    else if (aiPath.velocity.y > 0 && Mathf.Abs(aiPath.velocity.x) < Mathf.Abs(aiPath.velocity.y))
                    {
                        GameObject nuevaBala = Instantiate(balaGordock);
                        nuevaBala.GetComponent<BalaGordock>().contadorGordock = contador3;
                        nuevaBala.transform.position = transform.position;
                        nuevaBala.GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<SeguirAstarGordock>().valorDelParametroX, GetComponent<SeguirAstarGordock>().valorDelParametroY) * 5;
                        nuevaBala.transform.up = new Vector2(GetComponent<SeguirAstarGordock>().valorDelParametroX, GetComponent<SeguirAstarGordock>().valorDelParametroY);
                        nuevaBala.transform.Rotate(Vector3.forward * -90);
                        Destroy(nuevaBala, 1);
                        if (contador2 == 0)
                        {
                            Destroy(nuevaBala);
                        }
                        contador2++;
                        contador = 0;
                    }
                   
                    
                }
                else
                {
                   
                    if (aiPath.velocity.x > 0 && Mathf.Abs(aiPath.velocity.x) > Mathf.Abs(aiPath.velocity.y))
                    {
                        GameObject nuevaBala = Instantiate(balaGordock2);
                        nuevaBala.GetComponent<BalaGordock>().contadorGordock = contador3;
                        nuevaBala.transform.position = transform.position;
                        nuevaBala.GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<SeguirAstarGordock>().valorDelParametroX, GetComponent<SeguirAstarGordock>().valorDelParametroY) * 8;
                        nuevaBala.transform.up = new Vector2(GetComponent<SeguirAstarGordock>().valorDelParametroX, GetComponent<SeguirAstarGordock>().valorDelParametroY);
                        nuevaBala.transform.Rotate(Vector3.forward * -90);
                        Destroy(nuevaBala, 1);
                        if (contador2 == 0)
                        {
                            Destroy(nuevaBala);
                        }
                        contador2++;
                        contador = 0;
                    }

                    else if (aiPath.velocity.x < 0 && Mathf.Abs(aiPath.velocity.x) > Mathf.Abs(aiPath.velocity.y))
                    {
                        GameObject nuevaBala = Instantiate(balaGordock2);
                        nuevaBala.GetComponent<BalaGordock>().contadorGordock = contador3;
                        nuevaBala.transform.position = transform.position;
                        nuevaBala.GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<SeguirAstarGordock>().valorDelParametroX, GetComponent<SeguirAstarGordock>().valorDelParametroY) * 8;
                        nuevaBala.transform.up = new Vector2(GetComponent<SeguirAstarGordock>().valorDelParametroX, GetComponent<SeguirAstarGordock>().valorDelParametroY);
                        nuevaBala.transform.Rotate(Vector3.forward * -90);
                        Destroy(nuevaBala, 1);
                        if (contador2 == 0)
                        {
                            Destroy(nuevaBala);
                        }
                        contador2++;
                        contador = 0;
                    }

                    else if (aiPath.velocity.y < 0 && Mathf.Abs(aiPath.velocity.x) < Mathf.Abs(aiPath.velocity.y))
                    {
                        GameObject nuevaBala = Instantiate(balaGordock2);
                        nuevaBala.GetComponent<BalaGordock>().contadorGordock = contador3;
                        nuevaBala.transform.position = transform.position;
                        nuevaBala.GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<SeguirAstarGordock>().valorDelParametroX, GetComponent<SeguirAstarGordock>().valorDelParametroY) * 8;
                        nuevaBala.transform.up = new Vector2(GetComponent<SeguirAstarGordock>().valorDelParametroX, GetComponent<SeguirAstarGordock>().valorDelParametroY);
                        nuevaBala.transform.Rotate(Vector3.forward * -90);
                        Destroy(nuevaBala, 1);
                        if (contador2 == 0)
                        {
                            Destroy(nuevaBala);
                        }
                        contador2++;
                        contador = 0;
                    }
                    else if (aiPath.velocity.y > 0 && Mathf.Abs(aiPath.velocity.x) < Mathf.Abs(aiPath.velocity.y))
                    {
                        GameObject nuevaBala = Instantiate(balaGordock2);
                        nuevaBala.GetComponent<BalaGordock>().contadorGordock = contador3;
                        nuevaBala.transform.position = transform.position;
                        nuevaBala.GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<SeguirAstarGordock>().valorDelParametroX, GetComponent<SeguirAstarGordock>().valorDelParametroY) * 8;
                        nuevaBala.transform.up = new Vector2(GetComponent<SeguirAstarGordock>().valorDelParametroX, GetComponent<SeguirAstarGordock>().valorDelParametroY);
                        nuevaBala.transform.Rotate(Vector3.forward * -90);
                        Destroy(nuevaBala, 1);
                        if (contador2 == 0)
                        {
                            Destroy(nuevaBala);
                        }
                        contador2++;
                        contador = 0;
                    }
                }
               
            }  

                    if (time1 >= tiempoParaVolverADisparar)
                    {
                        puedeDisparar = true;
                        contador3++;
                        time1 = 0;
                    }
        

                if (GordockAnimator.GetBool("Disparando"))
                {
                    time2 += Time.deltaTime;

                    if (time2 >= 1)
                    {
                        GordockAnimator.SetBool("Disparando", false);
                        GordockAnimator.SetBool("SeMueve", true);
                        aiPath.maxSpeed = 1.5f;
                        time2 = 0;
                    }
                }


            
        }      


    }
}

