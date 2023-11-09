using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class JugadorDisparo : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject Arma;
    public GameObject puntoDeDisparo;
    public Camera cámara;
    public Vector2 direction;
    float tiempo;
    bool puedeDisparar=true;
   public float cdDisparo=0.6f;
    public float ángulo;

    private Animator direcciónMirada;

    void Start()
    {
        cámara = Camera.main;
        direcciónMirada = GetComponent<Animator>();
    }

    void Update()
    {
        Apuntar();
        Disparo();
        Recargando();
        ApuntarAnimación();
        //Debug.Log(cdDisparo);
    }

    void ApuntarAnimación()
    {
        direcciónMirada.SetFloat("Ángulo", ángulo);
       
        if (GameObject.Find("Mike").GetComponent<Rigidbody2D>().velocity.magnitude != 0)
        {
            direcciónMirada.SetFloat("Rapidez", 100);
        }
        else
        {
            //Debug.Log("no me animo");
            direcciónMirada.SetFloat("Rapidez", 0);
        }
            
    }

    void Apuntar()
    {
        Vector3 mousePosition = cámara.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePosition - Arma.transform.position;
        Arma.transform.up = direction.normalized;
        Arma.transform.Rotate(Vector3.forward * 90.0f);


        ángulo = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //Este devuelve un valor de -180 a 180
        
        if (ángulo < 0)
        {
            ángulo += 360;

            if (ángulo >= 315)
            {
                ángulo = 0;
            }
        }
        //Debug.Log(ángulo);

      
    }

    void Disparo()
    {
        if (Input.GetMouseButtonDown(0) && puedeDisparar==true)
        {
            puedeDisparar = false;
            GameObject nuevaBala = Instantiate(bulletPrefab);
            nuevaBala.transform.position = puntoDeDisparo.transform.position;
            nuevaBala.transform.up = Arma.transform.up;
            nuevaBala.GetComponent<JugadorBala>().direction = direction.normalized;
            
            //nuevaBala.transform.Rotate(Vector3.forward * 90.0f);
        }

       
    }

    void Recargando()
    {
        if (puedeDisparar==false)
        {
            /*Debug.Log("Iniciando");*/

            tiempo += Time.deltaTime;

            if (tiempo >= cdDisparo)
            {
                puedeDisparar = true;
                tiempo = 0;
            }
        }
    }
}