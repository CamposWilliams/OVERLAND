using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;
using UnityEngine.UI;

public class SistemaDeVida : MonoBehaviour
{
   public AudioSource MuerteMikeSonido;
   public float vidaM�ximaMike=10;
   public float vidaActualMike;
   float da�oEntrante;
   public bool PUAzulActivo;
   public bool sinVida;
   SpriteRenderer MikeSpr;
    int contador;
    public GameObject SangreAMIke;

    public string NombreScena = "";

    public Image barraDeVida;

    void Start()
    {
        MikeSpr = GetComponent<SpriteRenderer>();
        vidaActualMike = vidaM�ximaMike;
        ActualizarBarraDeVida();
        
    }

     public void BajarVida(float da�o)
    {
        GameObject nuevaSAngre = Instantiate(SangreAMIke);
        nuevaSAngre.transform.position = transform.position;
        Destroy(nuevaSAngre,0.22f);
        
        if(PUAzulActivo)
        {
            da�oEntrante = da�o/2;
                        StartCoroutine(CambiarColor());

        }
        else
        {
            da�oEntrante = da�o;
            StartCoroutine(CambiarColor());
        }
        //Debug.Log($"Recibiste {da�oEntrante} de da�o");
        vidaActualMike -= da�oEntrante;
       
        if( vidaActualMike <= 0 && contador==0)
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
    void ActualizarBarraDeVida()
    {
        float porcentajeVida = vidaActualMike / vidaM�ximaMike;
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


     void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("BalaBoss"))
        {
            BajarVida(-1);

        }

        if(collision.gameObject.CompareTag("Boss"))
        {
            BajarVida(-1);
        }


    }


}
