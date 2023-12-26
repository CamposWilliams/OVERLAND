using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;
using UnityEngine.UI;

public class SistemaDeVida : MonoBehaviour
{
   public AudioSource MuerteMikeSonido;
   public float vidaMáximaMike=45;
   public float vidaActualMike;
   float dañoEntrante;
   public bool PUAzulActivo;
   public bool sinVida;
   SpriteRenderer MikeSpr;
   int contador;
    public GameObject SangreAMIke;
     GameObject guardador;

    private string NombreScena = "PantallaDerrota";

    public Image barraDeVida;

    private void Awake()
    {
        guardador = GameObject.Find("GuardaDatosEntreEscena");
    }
    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 5 && guardador!=null)
        {
            vidaActualMike = guardador.GetComponent<GuardaDatos>().vidaDeMike;
        }
        MikeSpr = GetComponent<SpriteRenderer>();
        vidaActualMike = vidaMáximaMike;
        
        
    }
    private void Update()
    {
        ActualizarBarraDeVida();
    }

    public void BajarVida(float daño)
    {
        GameObject nuevaSAngre = Instantiate(SangreAMIke);
        nuevaSAngre.transform.position = transform.position;
        Destroy(nuevaSAngre,0.2f);
        
        if(PUAzulActivo)
        {
            dañoEntrante = daño/2;
                        StartCoroutine(CambiarColor());

        }
        else
        {
            dañoEntrante = daño;
            StartCoroutine(CambiarColor());
        }
        //Debug.Log($"Recibiste {dañoEntrante} de daño");
        vidaActualMike -= dañoEntrante;
       
        if( vidaActualMike <= 1 && contador==0)
        {
            contador++;
            MuerteMikeSonido.Play();
            sinVida = true;
            GetComponent<Collider2D>().enabled = false;
            StartCoroutine(Muriendo());
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            
        }
        ActualizarBarraDeVida();
    }
   public void ActualizarBarraDeVida()
    {
        float porcentajeVida = vidaActualMike / vidaMáximaMike;
        barraDeVida.fillAmount = porcentajeVida;
    }
    IEnumerator Muriendo()
    {
        GetComponent<Animator>().SetBool("Muere", true);
        yield return new WaitForSeconds(0.1f);
        GetComponent<Animator>().SetBool("Muere", false);
        yield return new WaitForSeconds(0.9f);
        SceneManager.LoadScene(NombreScena);
        gameObject.SetActive(false);

    }
    public void AumentarVida(float vida)
    {
        Debug.Log($"Recibiste {vida} de salud");
        
        vidaActualMike += vida;
       if(vidaActualMike>=vidaMáximaMike)
        {
            vidaActualMike = vidaMáximaMike;
        }
        
        if (vidaActualMike <= 0)
        {
            gameObject.SetActive(false);
        }
        ActualizarBarraDeVida();
    }

   public IEnumerator CambiarColor()
    {
        
        MikeSpr.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        MikeSpr.color = Color.white;
    }


     void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("BalaBoss"))
        {
            BajarVida(1f);

        }
      
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
      
            if (collision.gameObject.CompareTag("Boss"))
            {
                BajarVida(300);
            }
            
    }


}
