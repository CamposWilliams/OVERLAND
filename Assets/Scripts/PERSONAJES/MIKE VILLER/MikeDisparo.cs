using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MikeDisparo : MonoBehaviour
{
    public bool balaCreada;
    Rigidbody2D rb2DMike;
    public GameObject[] cajas;
    public Camera cam;
    float angulo;
    public float anguloConstante;
    Vector2 Direction;
    public GameObject balaPrefab;
    public Vector2 referencia;
    float contador;
    float bala;
    private void Start()
    {
       
        rb2DMike = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //Debug.Log(GameObject.Find("Mike").GetComponent<JugadorDisparo>().puedeDisparar);
        DireccionDelArma();
        //ArmaSecreta();
    }
    void  DireccionDelArma()
    {
       
            Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

            Direction = mousePosition - transform.position;

            angulo = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;

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
        
    }


    public void DireccionDeLaBala(GameObject balaPrefab, float numeroDeBala)
    {
        bala = numeroDeBala;
      
        if (balaCreada)
        {
            if (numeroDeBala == 0)
            {
              
                GetComponent<JugadorDisparo>().cdDisparo = 0.6f;
                GameObject nuevaBala = Instantiate(balaPrefab);
                nuevaBala.GetComponent<JugadorBala>().numeroDeBala = numeroDeBala;

                if (anguloConstante == 0)
                {
                    nuevaBala.transform.position = cajas[0].transform.position;
                    nuevaBala.transform.Rotate(Vector3.forward * -90);
                    nuevaBala.GetComponent<JugadorBala>().direccionBala = Vector2.right;


                }

                else if (anguloConstante == 180)
                {
                    nuevaBala.transform.position = cajas[2].transform.position;
                    nuevaBala.transform.Rotate(Vector3.forward * 90);
                    nuevaBala.GetComponent<JugadorBala>().direccionBala = Vector2.left;


                }

                else if (anguloConstante == 270)
                {
                    nuevaBala.transform.position = cajas[3].transform.position;
                    nuevaBala.transform.Rotate(Vector3.forward * 180);
                    nuevaBala.GetComponent<JugadorBala>().direccionBala = Vector2.down;


                }
                else if (anguloConstante == 90)
                {
                    nuevaBala.transform.position = cajas[1].transform.position;
                    nuevaBala.transform.Rotate(Vector3.forward * 0);
                    nuevaBala.GetComponent<JugadorBala>().direccionBala = Vector2.up;

                }
            }

             else if (numeroDeBala == 1)
             {
               
                GetComponent<JugadorDisparo>().cdDisparo = 0.2f;
                GameObject nuevaBala = Instantiate(balaPrefab);
                nuevaBala.GetComponent<JugadorBala>().numeroDeBala = numeroDeBala;

                if (anguloConstante == 0)
                {

                    nuevaBala.transform.position = cajas[0].transform.position;
                    nuevaBala.transform.Rotate(Vector3.forward * -90);
                    nuevaBala.GetComponent<JugadorBala>().direccionBala = Vector2.right;


                }

                else if (anguloConstante == 180)
                {
                    nuevaBala.transform.position = cajas[2].transform.position;
                    nuevaBala.transform.Rotate(Vector3.forward * 90);
                    nuevaBala.GetComponent<JugadorBala>().direccionBala = Vector2.left;


                }

                else if (anguloConstante == 270)
                {
                    nuevaBala.transform.position = cajas[3].transform.position;
                    nuevaBala.transform.Rotate(Vector3.forward * 180);
                    nuevaBala.GetComponent<JugadorBala>().direccionBala = Vector2.down;


                }
                else if (anguloConstante == 90)
                {
                    nuevaBala.transform.position = cajas[1].transform.position;
                    nuevaBala.transform.Rotate(Vector3.forward * 0);
                    nuevaBala.GetComponent<JugadorBala>().direccionBala = Vector2.up;

                }
             }

            else if (numeroDeBala == 2)
            {
                
                GetComponent<JugadorDisparo>().cdDisparo = 0.6f;
                if (anguloConstante == 0)
                {

                    if (contador <= 3)
                    {
                        Debug.Log(contador);
                        GetComponent<JugadorDisparo>().puedeDisparar = false;

                       
                        if (!IsInvoking("Subfusil"))
                        {
                            InvokeRepeating("Subfusil", 0, 0.09f);
                        }
                    }

                }

                else if (anguloConstante == 180)
                {
                    if (contador <= 3)
                    {
                        Debug.Log(contador);
                        GetComponent<JugadorDisparo>().puedeDisparar = false;

                      
                        if (!IsInvoking("Subfusil"))
                        {
                            InvokeRepeating("Subfusil", 0, 0.09f);
                        }
                    }



                }

                else if (anguloConstante == 270)
                {
                    if (contador <= 3)
                    {
                        Debug.Log(contador);
                        GetComponent<JugadorDisparo>().puedeDisparar = false;

                       
                        if (!IsInvoking("Subfusil"))
                        {
                            InvokeRepeating("Subfusil", 0, 009f);
                        }
                    }


                }
                else if (anguloConstante == 90)
                {
                    if (contador <= 3)
                    {
                        //Debug.Log(contador);
                        GetComponent<JugadorDisparo>().puedeDisparar = false;

                       
                        if (!IsInvoking("Subfusil"))
                        {
                            InvokeRepeating("Subfusil", 0, 0.09f);
                        }
                    }


                }

            }

            else if (numeroDeBala == 3)
           
            {
               
                GameObject nuevaBala = Instantiate(balaPrefab);
                GameObject nuevaBala2 = Instantiate(balaPrefab);
                GameObject nuevaBala3 = Instantiate(balaPrefab);

                nuevaBala.GetComponent<JugadorBala>().numeroDeBala = bala;
                nuevaBala2.GetComponent<JugadorBala>().numeroDeBala = bala;
                nuevaBala3.GetComponent<JugadorBala>().numeroDeBala = bala;

                if (anguloConstante == 0)
                {
                    
                    nuevaBala.transform.position = cajas[0].transform.position;
                    nuevaBala.transform.Rotate(Vector3.forward * -90);
                    nuevaBala.GetComponent<JugadorBala>().direccionBala=Vector2.right*1.5f;


                   
                    nuevaBala2.transform.position = cajas[0].transform.position;
                    nuevaBala2.transform.Rotate(Vector3.forward * -90);
                    nuevaBala2.GetComponent<JugadorBala>().direccionBala =new Vector2 (1.5f,0.15f);
                    nuevaBala2.transform.up = new Vector2(1.5f, 0.15f);


                    nuevaBala3.transform.position = cajas[0].transform.position;
                    nuevaBala3.transform.Rotate(Vector3.forward * -90);
                    nuevaBala3.GetComponent<JugadorBala>().direccionBala = new Vector2(1.5f,-0.15f);
                    nuevaBala3.transform.up = new Vector2(1.5f, -0.15f);



                }

                else if (anguloConstante == 180)
                {
                    nuevaBala.transform.position = cajas[2].transform.position;
                    nuevaBala.transform.Rotate(Vector3.forward * 90);
                    nuevaBala.GetComponent<JugadorBala>().direccionBala = Vector2.left*1.5f;



                    nuevaBala2.transform.position = cajas[2].transform.position;
                    nuevaBala2.transform.Rotate(Vector3.forward * 90);
                    nuevaBala2.GetComponent<JugadorBala>().direccionBala = new Vector2(1.5f, 0.15f)*-1;
                    nuevaBala2.transform.up = new Vector2(1.5f, 0.15f) * -1;

                    nuevaBala3.transform.position = cajas[2].transform.position;
                    nuevaBala3.transform.Rotate(Vector3.forward * 90);
                    nuevaBala3.GetComponent<JugadorBala>().direccionBala = new Vector2(1.5f, -0.15f)*-1;
                    nuevaBala3.transform.up = new Vector2(1.5f, -0.15f) * -1;



                }

                else if (anguloConstante == 270)
                {
                    nuevaBala.transform.position = cajas[3].transform.position;
                    nuevaBala.transform.Rotate(Vector3.forward * 180);
                    nuevaBala.GetComponent<JugadorBala>().direccionBala = Vector2.down*1.5f;

                    
                    nuevaBala2.transform.position = cajas[3].transform.position;
                    nuevaBala2.transform.Rotate(Vector3.forward * 180);
                    nuevaBala2.GetComponent<JugadorBala>().direccionBala = Quaternion.Euler(0, 0, -90)*new Vector2(1.5f, 0.15f);
                    nuevaBala2.transform.up = Quaternion.Euler(0, 0, -90) * new Vector2(1.5f, 0.15f);


                    nuevaBala3.transform.position = cajas[3].transform.position;
                    nuevaBala3.transform.Rotate(Vector3.forward * 180);
                    nuevaBala3.GetComponent<JugadorBala>().direccionBala = Quaternion.Euler(0, 0, -90)*new Vector2(1.5f, -0.15f);
                    nuevaBala3.transform.up = Quaternion.Euler(0, 0, -90) * new Vector2(1.5f, -0.15f);
                }
                else if (anguloConstante == 90)
                {

                    nuevaBala.transform.position = cajas[1].transform.position;
                    nuevaBala.transform.Rotate(Vector3.forward * 0);
                    nuevaBala.GetComponent<JugadorBala>().direccionBala = Vector2.up*1.5f;

                    
                    nuevaBala2.transform.position = cajas[1].transform.position;
                    nuevaBala2.transform.Rotate(Vector3.forward * 0);
                    nuevaBala2.GetComponent<JugadorBala>().direccionBala = Quaternion.Euler(0, 0, 90)* new Vector2(1.5f, 0.15f);
                    nuevaBala2.transform.up = Quaternion.Euler(0, 0, 90) * new Vector2(1.5f, 0.15f);

                    nuevaBala3.transform.position = cajas[1].transform.position;
                    nuevaBala3.transform.Rotate(Vector3.forward * 0);
                    nuevaBala3.GetComponent<JugadorBala>().direccionBala = Quaternion.Euler(0, 0, 90)* new Vector2(1.5f, -0.15f);
                    nuevaBala3.transform.up = Quaternion.Euler(0, 0, 90) * new Vector2(1.5f, -0.15f);

                }
            }


        }

        balaCreada = false;
    }

    void Subfusil()
    {
        GameObject nuevaBala = Instantiate(balaPrefab);
        nuevaBala.GetComponent<JugadorBala>().numeroDeBala = bala;
        


        switch (anguloConstante)
            {
              
                 case 0:
           
                     nuevaBala.transform.position = cajas[0].transform.position;
                     nuevaBala.transform.Rotate(Vector3.forward * -90);
                     nuevaBala.GetComponent<JugadorBala>().direccionBala = Vector2.right;
                     contador++;
                    
                      if (contador == 3)
                      {
                
                            if (IsInvoking("Subfusil"))
                            {
                                contador = 0;
                                CancelInvoke("Subfusil");
                            }

                      }

                      break;

                
                case 180:

                        nuevaBala.transform.position = cajas[2].transform.position;
                        nuevaBala.transform.Rotate(Vector3.forward * 90);
                        nuevaBala.GetComponent<JugadorBala>().direccionBala = Vector2.left;
                        contador++;
                        if (contador == 3)
                        {
                          
                            if (IsInvoking("Subfusil"))
                            {
                                contador = 0;
                                CancelInvoke("Subfusil");
                            }

                        }
                        break;

                case 270:

                        nuevaBala.transform.position = cajas[3].transform.position;
                        nuevaBala.transform.Rotate(Vector3.forward * 180);
                        nuevaBala.GetComponent<JugadorBala>().direccionBala = Vector2.down;
                        contador++; 
                        if (contador == 3)
                        {
                      
                            if (IsInvoking("Subfusil"))
                            {
                                contador = 0;
                                CancelInvoke("Subfusil");
                            }

                        }
                        break;

            case 90:

                nuevaBala.transform.position = cajas[1].transform.position;
                nuevaBala.transform.Rotate(Vector3.forward * 0);
                nuevaBala.GetComponent<JugadorBala>().direccionBala = Vector2.up;
                contador++;
                if (contador == 3)
                {
                   
                    if (IsInvoking("Subfusil"))
                    {
                        contador = 0;
                        CancelInvoke("Subfusil");
                    }

                }
                break;
        }


    }

}
