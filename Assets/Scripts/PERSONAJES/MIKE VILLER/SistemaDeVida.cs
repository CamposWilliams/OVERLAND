using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;
using UnityEngine.UI;

public class SistemaDeVida : MonoBehaviour
{
   public AudioSource MuerteMikeSonido;
   public float vidaMáximaMike=10;
   public float vidaActualMike;
   float dañoEntrante;
   public bool PUAzulActivo;
   public bool sinVida;
   SpriteRenderer MikeSpr;

    public string NombreScena = "";

    public Image barraDeVida;

    void Start()
    {
        MikeSpr = GetComponent<SpriteRenderer>();
        vidaActualMike = vidaMáximaMike;
        ActualizarBarraDeVida();
        
    }

     public void BajarVida(float daño)
    {
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
       
        if( vidaActualMike <= 0)
        {
            MuerteMikeSonido.Play();
            sinVida = true;
            GetComponent<Collider2D>().enabled = false;
            StartCoroutine(Muriendo());
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            
        }
        ActualizarBarraDeVida();
    }
    void ActualizarBarraDeVida()
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


}
