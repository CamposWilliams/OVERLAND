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
    public bool puedeDisparar = true;
   public bool puedeDisparar2;
   public bool disparandoEspecial;
   public int contador;
    public int contador2;
    bool dañoContinuo;
    GameObject Mike;

    private void Awake()
    {
        Mike = GameObject.Find("Mike");
    }
    private void Start()
    {
        VomentAnimator = GetComponent<Animator>();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && GetComponent<VidaVoment>().muriendo == false)
        {
            dañoContinuo = true;
        }
       
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && GetComponent<VidaVoment>().muriendo == false)
        {
            dañoContinuo = false;
            time2 = 0;
        }
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")&& GetComponent<VidaVoment>().muriendo == false)
        {
            //Debug.Log("Entre");
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

        DañoContinuoPorChoque();
        
    }
    void DañoContinuoPorChoque()
    {
        if (dañoContinuo)
        {
            time2 += Time.deltaTime;
            if (time2 >= 0.6f)
            {
               Mike.GetComponent<SistemaDeVida>().BajarVida(dañoPorGolpe);
                time2 = 0;
            }
        }
       
    }
    void DispararGordock()
    {
        if (disparando)
        {
           
            if (puedeDisparar==true && disparandoEspecial==false)
            {
               
                //Debug.Log(contador);

                if (aiPath.velocity.x > 0 && Mathf.Abs(aiPath.velocity.x) > Mathf.Abs(aiPath.velocity.y))
                {
                    GameObject nuevaBala = Instantiate(balaVomet);
                    nuevaBala.transform.position = transform.position;
                    nuevaBala.GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<SeguirAstarVomet>().valorDelParametroX, GetComponent<SeguirAstarVomet>().valorDelParametroY) * 5;
                    nuevaBala.transform.up = new Vector2(GetComponent<SeguirAstarVomet>().valorDelParametroX, GetComponent<SeguirAstarVomet>().valorDelParametroY);
                    nuevaBala.transform.Rotate(Vector3.forward * -90);
                    Destroy(nuevaBala, 1);
                    contador++;
                }

                else if (aiPath.velocity.x < 0 && Mathf.Abs(aiPath.velocity.x) > Mathf.Abs(aiPath.velocity.y))
                {
                    GameObject nuevaBala = Instantiate(balaVomet);
                    nuevaBala.transform.position = transform.position;
                    nuevaBala.GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<SeguirAstarVomet>().valorDelParametroX, GetComponent<SeguirAstarVomet>().valorDelParametroY) * 5;
                    nuevaBala.transform.up = new Vector2(GetComponent<SeguirAstarVomet>().valorDelParametroX, GetComponent<SeguirAstarVomet>().valorDelParametroY);
                    nuevaBala.transform.Rotate(Vector3.forward * -90);
                    Destroy(nuevaBala, 1);
                    contador++;
                }

                else if (aiPath.velocity.y < 0 && Mathf.Abs(aiPath.velocity.x) < Mathf.Abs(aiPath.velocity.y))
                {
                    GameObject nuevaBala = Instantiate(balaVomet);
                    nuevaBala.transform.position = transform.position;
                    nuevaBala.GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<SeguirAstarVomet>().valorDelParametroX, GetComponent<SeguirAstarVomet>().valorDelParametroY) * 5;
                    nuevaBala.transform.up = new Vector2(GetComponent<SeguirAstarVomet>().valorDelParametroX, GetComponent<SeguirAstarVomet>().valorDelParametroY);
                    nuevaBala.transform.Rotate(Vector3.forward * 90);
                    Destroy(nuevaBala, 1);
                    contador++;
                }
                else if (aiPath.velocity.y > 0 && Mathf.Abs(aiPath.velocity.x) < Mathf.Abs(aiPath.velocity.y))
                {
                    GameObject nuevaBala = Instantiate(balaVomet);
                    nuevaBala.transform.position = transform.position;
                    nuevaBala.GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<SeguirAstarVomet>().valorDelParametroX, GetComponent<SeguirAstarVomet>().valorDelParametroY) * 5;
                    nuevaBala.transform.up = new Vector2(GetComponent<SeguirAstarVomet>().valorDelParametroX, GetComponent<SeguirAstarVomet>().valorDelParametroY);
                    nuevaBala.transform.Rotate(Vector3.forward * -90);
                    Destroy(nuevaBala, 1);
                    contador++;
                }   
                   
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
            
            

            if (VomentAnimator.GetFloat("ValorX")==1 && VomentAnimator.GetFloat("ValorY") == 0)
            {
                GameObject nuevaBala = Instantiate(balaVomet);
                nuevaBala.transform.position = transform.position;
                nuevaBala.GetComponent<Rigidbody2D>().velocity = new Vector2(VomentAnimator.GetFloat("ValorX"), VomentAnimator.GetFloat("ValorY")) * 5;
                nuevaBala.transform.up = new Vector2(GetComponent<SeguirAstarVomet>().valorDelParametroX, GetComponent<SeguirAstarVomet>().valorDelParametroY);
                nuevaBala.transform.Rotate(Vector3.forward * -90);
                Destroy(nuevaBala, 1);
                contador2++;
            }

            else if (VomentAnimator.GetFloat("ValorX") == -1 && VomentAnimator.GetFloat("ValorY") == 0)
            {
                GameObject nuevaBala = Instantiate(balaVomet);
                nuevaBala.transform.position = transform.position;
                nuevaBala.GetComponent<Rigidbody2D>().velocity = new Vector2(VomentAnimator.GetFloat("ValorX"), VomentAnimator.GetFloat("ValorY")) * 5;
                nuevaBala.transform.up = new Vector2(GetComponent<SeguirAstarVomet>().valorDelParametroX, GetComponent<SeguirAstarVomet>().valorDelParametroY);
                nuevaBala.transform.Rotate(Vector3.forward * -90);
                Destroy(nuevaBala, 1);
                contador2++;
            }

            else if (VomentAnimator.GetFloat("ValorX") == 0 && VomentAnimator.GetFloat("ValorY") == -1)
            {
                GameObject nuevaBala = Instantiate(balaVomet);
                nuevaBala.transform.position = transform.position;
                nuevaBala.GetComponent<Rigidbody2D>().velocity = new Vector2(VomentAnimator.GetFloat("ValorX"), VomentAnimator.GetFloat("ValorY")) * 5;
                nuevaBala.transform.up = new Vector2(GetComponent<SeguirAstarVomet>().valorDelParametroX, GetComponent<SeguirAstarVomet>().valorDelParametroY);
                nuevaBala.transform.Rotate(Vector3.forward * 90);
                Destroy(nuevaBala, 1);
                contador2++;
            }
            else if (VomentAnimator.GetFloat("ValorX") == 0 && VomentAnimator.GetFloat("ValorY") == 1)
            {
                GameObject nuevaBala = Instantiate(balaVomet);
                nuevaBala.transform.position = transform.position;
                nuevaBala.GetComponent<Rigidbody2D>().velocity = new Vector2(VomentAnimator.GetFloat("ValorX"), VomentAnimator.GetFloat("ValorY")) * 5;
                nuevaBala.transform.up = new Vector2(GetComponent<SeguirAstarVomet>().valorDelParametroX, GetComponent<SeguirAstarVomet>().valorDelParametroY);
                nuevaBala.transform.Rotate(Vector3.forward * -90);
                Destroy(nuevaBala, 1);
                contador2++;
            }

            //Debug.Log(contador2);

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
