using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SceneManagement;

public class Jugador : MonoBehaviour
{
    public float rapidez;
    public float rapidezBala;
    Vector2 direcciónBala=new (1,0);
    Rigidbody2D rb2D;
    GameObject balaPrefabInicial;
    GameObject balaPrefabActual;
    public float municiónActual;
    
    public float vidaInicial;
    public float vidaActual;
    bool puedeDisparar=true;
    public float tiempoDeRecarga;
    public float tiempo;
    public float contador2=2;
    public float contador1=1;
    public List<GameObject> listaDePrefabs = new();
    public List<float> ListaDeMunición=new();

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        vidaActual = vidaInicial;
        balaPrefabInicial = listaDePrefabs[0];
        balaPrefabActual = balaPrefabInicial;
        municiónActual = ListaDeMunición[0];
    }

    void Update()
    {
        Movimiento();
        Disparando();
        CondiciónDeVictoriaNivel1();
        CambioDeBala();
    }

    void CambioDeBala()
    {
        
        if(Input.GetKeyDown(KeyCode.Q))
        {
            contador1++;
           
            if (contador1 % 2==0)
            {
               
                balaPrefabActual = listaDePrefabs[1];
                municiónActual = ListaDeMunición[1];
            }
            else
            {
                balaPrefabActual= listaDePrefabs[0];
                municiónActual = ListaDeMunición[0];
            }
            
            
        }
    }
  
    void Movimiento()
    {
        float xInput=Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");

        rb2D.velocity = new Vector2(xInput, yInput) * rapidez;
        if (new Vector2(xInput, yInput) != Vector2.zero)
       
        {
            direcciónBala = new Vector2(xInput, yInput).normalized;
        }
       

    }

    void  Disparando()
    {

        if(puedeDisparar==true)
        {
            if (ListaDeMunición[0]==municiónActual)
            {
                if (Input.GetKey(KeyCode.Mouse0) && municiónActual > 0)
                {

                    puedeDisparar = false;
                    GameObject nuevaBala = Instantiate(balaPrefabActual);
                    nuevaBala.transform.position = transform.position;

                    Rigidbody2D rb2DNuevaBala = nuevaBala.GetComponent<Rigidbody2D>();


                    rb2DNuevaBala.velocity = direcciónBala * rapidezBala;

                    municiónActual--;
                    ListaDeMunición[0] = municiónActual;


                }
            }

            else
            {
                if (Input.GetKey(KeyCode.Mouse0) && municiónActual > 0)
                {

                    puedeDisparar = false;
                    GameObject nuevaBala = Instantiate(balaPrefabActual);
                    nuevaBala.transform.position = transform.position;

                    Rigidbody2D rb2DNuevaBala = nuevaBala.GetComponent<Rigidbody2D>();


                    rb2DNuevaBala.velocity = direcciónBala * rapidezBala;

                    municiónActual--;
                    ListaDeMunición[1] = municiónActual;


                }
            }
            
        }

        Recargando();
    }

    void Recargando()
    {
        if (puedeDisparar == false)
        {
            tiempo += Time.deltaTime;
          
            if (tiempo >= tiempoDeRecarga)
            {
                puedeDisparar= true;
                tiempo = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Munición"))
        {
            municiónActual++;
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("ObjetoCurativo"))
        {
            vidaActual++;
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Enemigo"))
        {
            vidaActual--;
            
            if(vidaActual <= 0)
            {
                Destroy(gameObject);
                SceneManager.LoadScene(5);
            }
        }

        if (collision.CompareTag("BalaEnemiga"))
        {
            vidaActual--;
            Destroy(collision.gameObject) ;
            if( vidaActual <= 0)
            {
                Destroy(gameObject);
                SceneManager.LoadScene(5);
            }
        }
    }

    void CondiciónDeVictoriaNivel1()
    {
        if (contador2 == 0)
        {
            SceneManager.LoadScene(3);
        }
    }




}
