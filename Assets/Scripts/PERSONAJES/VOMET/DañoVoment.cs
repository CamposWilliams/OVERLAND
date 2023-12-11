using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoVoment : MonoBehaviour
{
    public AIPath aiPath;
    float dañoPorGolpe = 3;
    float time1;
    float time2;    
    public float tiempoParaVolverADisparar = 5;
    float cadenciaDeTiro = 0.3f;
    Animator VomentAnimator;
    bool disparando;
    public GameObject balaVomet;
    bool puedeDisparar = true;
    bool puedeDisparar2;
    bool disparandoEspecial;
    int contador;
    int contador2;
    

    private void Start()
    {
        VomentAnimator = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<SistemaDeVida>().BajarVida(dañoPorGolpe);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Entre");
            disparando = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            disparando = false;
        }

    }
    private void Update()
    {
         if(aiPath.enabled)
        {
            if (GetComponent<VidaVoment>().muriendo == false)
            {
                //Debug.Log(time1);
                DispararGordock();
                ReactivarAnimacionYBala();
            }
        }
      
        
    }

    void DispararGordock()
    {
        if (disparando)
        {
           
            if (puedeDisparar==true && disparandoEspecial==false)
            {
                GameObject nuevaBala = Instantiate(balaVomet);
                nuevaBala.transform.position = transform.position;
                nuevaBala.GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<SeguirAstarVomet>().valorDelParametroX, GetComponent<SeguirAstarVomet>().valorDelParametroY) * 5;
                Destroy(nuevaBala, 1);               
                contador++;
                Debug.Log(contador);

                if (contador == 16)
                {
                
                    puedeDisparar= false;
                    puedeDisparar2 = true;
                    disparandoEspecial= true;
                    


                    if (!IsInvoking("AtaqueEspecial"))
                    {
                       
                        InvokeRepeating("AtaqueEspecial", 2f, 0.2f);
                    }
                }

                else
                {
                    puedeDisparar = false;
                }

            }
           
        }  

    }

    void ReactivarAnimacionYBala()
    {      

        if (puedeDisparar==false && disparandoEspecial==false)
        {
            
            time1 += Time.deltaTime;

            if (time1 >= cadenciaDeTiro)
            {

                puedeDisparar = true;
                time1 = 0;
            }
           
        }
        

    }
    void AtaqueEspecial()
    {
        if(puedeDisparar2)
        {
            VomentAnimator.SetBool("Disparando", true);
            aiPath.maxSpeed = 0;
            GameObject nuevaBala = Instantiate(balaVomet);
            nuevaBala.transform.position = transform.position;
            nuevaBala.GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<SeguirAstarVomet>().valorDelParametroX, GetComponent<SeguirAstarVomet>().valorDelParametroY) * 5;
            Destroy(nuevaBala, 1);
            contador2++;
            Debug.Log(contador2);

            if (contador2 == 10)
            {
                contador = 0;
                contador2 = 0;
                puedeDisparar2 = false;
                puedeDisparar = true;
                disparandoEspecial = false;
                VomentAnimator.SetBool("Disparando", false);
                aiPath.maxSpeed = 3.3f;
                CancelInvoke("AtaqueEspecial");
               
            }
           
        }
       
    }

}
