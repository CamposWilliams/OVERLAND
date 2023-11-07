using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class JugadorDisparo : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject Arma;
    public GameObject puntoDeDisparo;
    public Camera c�mara;
    public Vector2 direction;
    float tiempo;
    bool puedeDisparar=true;
   public float cdDisparo=0.6f;

    private Animator direcci�nMirada;

    void Start()
    {
        c�mara = Camera.main;
        direcci�nMirada = GetComponent<Animator>();
    }

    void Update()
    {
        Apuntar();
        Disparo();
        Recargando();
        //Debug.Log(cdDisparo);
    }


    void Apuntar()
    {
        Vector3 mousePosition = c�mara.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePosition - Arma.transform.position;
        Arma.transform.up = direction.normalized;
        Arma.transform.Rotate(Vector3.forward * 90.0f);


        float �ngulo = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //Este devuelve un valor de -180 a 180
        
        if (�ngulo < 0)
        {
            �ngulo += 360;

            if (�ngulo >= 315)
            {
                �ngulo = 0;
            }
        }
        //Debug.Log(�ngulo);

        direcci�nMirada.SetFloat("�ngulo", �ngulo);
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