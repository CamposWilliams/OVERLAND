using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuardaDatos : MonoBehaviour
{
    public float vidaDeMike;
    public int balasSubfusil;
    public int balasRifle;
    public int balasEspecial;
    public int almacenSubfusil;
    public int almacenRifle;
    public int almacenEspecial;
    public int armaActual;
    public string animacionArmaActual;
    GameObject Mike;
    int contador;
 
    public static GuardaDatos instance;

    private void Update()
    {
        Mike = GameObject.Find("Mike");
        ActualizarDatos();
        if (SceneManager.GetActiveScene().buildIndex == 2 && Mike!=null)
        {
            armaActual= (int)Mike.GetComponent<JugadorDisparo>().CambioArma;
            vidaDeMike = Mike.GetComponent<SistemaDeVida>().vidaActualMike;
            balasSubfusil = Mike.GetComponent<JugadorDisparo>().AmmoSubfusil;
            balasRifle = Mike.GetComponent<JugadorDisparo>().AmmoRifle;
            balasEspecial = Mike.GetComponent<JugadorDisparo>().AmmoArmaEspecial;
            almacenSubfusil = Mike.GetComponent<JugadorDisparo>().almacenBulletSubfusil;
            almacenRifle = Mike.GetComponent<JugadorDisparo>().almacenBulletRifle;
            almacenEspecial = Mike.GetComponent<JugadorDisparo>().almacenBulletEspecial;
          
            Debug.Log(animacionArmaActual);
        }

     
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

       
    }

    public void ActualizarDatos()
    {
        if (SceneManager.GetActiveScene().buildIndex == 5 && contador ==0)
        {
            Mike = GameObject.Find("Mike");
            Mike.GetComponent<SistemaDeVida>().vidaActualMike = vidaDeMike;
            Mike.GetComponent<JugadorDisparo>().AmmoSubfusil = balasSubfusil;
            Mike.GetComponent<JugadorDisparo>().AmmoRifle = balasRifle;
            Mike.GetComponent<JugadorDisparo>().AmmoArmaEspecial = balasEspecial;
            Mike.GetComponent<JugadorDisparo>().almacenBulletSubfusil = almacenSubfusil;
            Mike.GetComponent<JugadorDisparo>().almacenBulletRifle = almacenRifle;
            Mike.GetComponent<JugadorDisparo>().almacenBulletEspecial = almacenEspecial;
            Mike.GetComponent<JugadorDisparo>().CambioArma = armaActual;
            
            contador++;
        }
    }
}
