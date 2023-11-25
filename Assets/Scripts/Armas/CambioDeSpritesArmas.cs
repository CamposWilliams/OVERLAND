using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioDeSpritesArmas : MonoBehaviour
{
    public Sprite[] ArmasSprites;
    private SpriteRenderer armaSpr;
    private int numeroDeArma = 0;

    private void Start()
    {
        armaSpr=GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        VerificarArmaActual();
        CambiarArmas();
    }

    void CambiarArmas()
    {
        switch (numeroDeArma)
        {
            case 0:
                armaSpr.sprite = ArmasSprites[0]; break;
            case 1:
                armaSpr.sprite = ArmasSprites[1]; break;
            case 2:
                armaSpr.sprite = ArmasSprites[2]; break;
            case 3:
                armaSpr.sprite = ArmasSprites[3]; break;


        }
    }
    
    void VerificarArmaActual()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            numeroDeArma++;

            if(numeroDeArma > 4) //Cuando se quite el cuchillo del script JugadorDisparo cambialo a >3
            {
                numeroDeArma = 0;
            }
        }
    }
}
