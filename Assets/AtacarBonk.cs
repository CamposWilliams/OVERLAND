using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtacarBonk : MonoBehaviour
{
    float time;
    bool atacando;
    bool puedeAtacar=true;
    public Animator BonkAnimator;


    private void Update()
    {
        DesactivarAnimacionAtaque();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") && puedeAtacar)
        {
            BonkAnimator.SetBool("Atacando", true);
            puedeAtacar = false;
            atacando = true;

        }
    }

    void DesactivarAnimacionAtaque()
    {
        if (atacando)
        {
            time += Time.time;

            if (time == 1)
            {
                BonkAnimator.SetBool("Atacando", false);
                puedeAtacar = true;
                time = 0;
            }
        }



    }
}
