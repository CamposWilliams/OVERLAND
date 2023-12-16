using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueBonk : MonoBehaviour
{
    float time1;
    float time2;
    bool atacando;
    bool puedeAtacar;
    public Animator BonkAnimator;
    public AIPath aiPath;
    bool mantenerAnimacionDeAtaque;
    GameObject Mike;
    private void Awake()
    {
        Mike = GameObject.Find("Mike");
    }

    private void Update()
    {
        AnimacionAtaque();
        //Debug.Log(puedeAtacar);
        //Debug.Log(mantenerAnimacionDeAtaque);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {      
            puedeAtacar = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {

            puedeAtacar = false;
            BonkAnimator.SetBool("Atacando", false);
            aiPath.maxSpeed = 2.9f;
            time1 = 0;
            time2 = 0;

        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            time2 += Time.deltaTime;
            if (time2 >= 0.65f)
            {
                //Debug.Log("BonkEjecutandose");
                collision.GetComponent<SistemaDeVida>().BajarVida(2);
                time2 = 0;
            }          
        }
    }

    void AnimacionAtaque()
    {
        if (puedeAtacar)
        {
            
            aiPath.maxSpeed = 0;
            BonkAnimator.SetBool("Atacando", true);
            
            //Debug.Log(time1);                     
        }

        else
        {
            time1 += Time.deltaTime;
            if (time1 >= 0.8f)
            {
                BonkAnimator.SetBool("Atacando", false);

                aiPath.maxSpeed = 2.9f;
                time1 = 0;
                puedeAtacar = false;

            }
        }

    }

    IEnumerator VolverActivar()
    {
        BonkAnimator.SetBool("SeMueve", false);
        BonkAnimator.SetBool("Atacando", true);
        yield return new WaitForSeconds(0.1f);
        aiPath.maxSpeed = 0;

    }
}
