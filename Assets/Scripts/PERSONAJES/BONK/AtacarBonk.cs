using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AtacarBonk : MonoBehaviour
{
    float time1;
    float time2;
    bool atacando;
    bool puedeAtacar=true;
    public Animator BonkAnimator;
    public AIPath aiPath;
    bool mantenerAnimacionDeAtaque;


    private void Update()
    {
        DesactivarAnimacionAtaque();
       
        //Debug.Log(mantenerAnimacionDeAtaque);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") && puedeAtacar)
        {
            Debug.Log("Hola");         
            puedeAtacar = false;
            mantenerAnimacionDeAtaque = true;
            StartCoroutine(VolverActivar());

        }
    }

    void DesactivarAnimacionAtaque()
    {
        if (!puedeAtacar)
        {
            time1 += Time.deltaTime;
            Debug.Log(time1);

            if (time1>=1 && mantenerAnimacionDeAtaque)
            {
                BonkAnimator.SetBool("Atacando", false);
                BonkAnimator.SetBool("SeMueve", true);
                aiPath.maxSpeed = 2.9f;
                mantenerAnimacionDeAtaque = false;

            }

            if (time1 >= 3)
            {
                time1 = 0;
                puedeAtacar = true;

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
