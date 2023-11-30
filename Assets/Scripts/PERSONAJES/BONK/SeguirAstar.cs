using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SeguirAstar : MonoBehaviour
{

    Animator BonkAnimacion;
    private AIPath aiPath;
    public Transform MikeTrf;
    float valorDelParametroX;
    float valorDelParametroY;


    void Start()
    {
        aiPath = GetComponent<AIPath>();
        BonkAnimacion = GetComponent<Animator>();

    }


    private void Update()
    {

        SeguimientoDeAnimacion();
        AtaqueAnimacion();

    }

  

    void AtaqueAnimacion()
    {

    }


    void SeguimientoDeAnimacion()
    {
        if (aiPath.velocity != Vector3.zero)
        {
            BonkAnimacion.SetBool("SeMueve", true);

            if (aiPath.velocity.x > 0 && Mathf.Abs(aiPath.velocity.x) > Mathf.Abs(aiPath.velocity.y))
            {
                //Debug.Log("Derecha");
                BonkAnimacion.SetFloat("ValorY", 0);
                BonkAnimacion.SetFloat("ValorX", 1);
                valorDelParametroX = BonkAnimacion.GetFloat("ValorX");
                valorDelParametroY = BonkAnimacion.GetFloat("ValorY");
            }

            else if (aiPath.velocity.x < 0 && Mathf.Abs(aiPath.velocity.x) > Mathf.Abs(aiPath.velocity.y))
            {
                //Debug.Log("Izquierda");
                BonkAnimacion.SetFloat("ValorY", 0);
                BonkAnimacion.SetFloat("ValorX", -1);
                valorDelParametroX = BonkAnimacion.GetFloat("ValorX");
                valorDelParametroY = BonkAnimacion.GetFloat("ValorY");
            }

            else if (aiPath.velocity.y < 0 && Mathf.Abs(aiPath.velocity.x) < Mathf.Abs(aiPath.velocity.y))
            {
                BonkAnimacion.SetFloat("ValorX", 0);
                BonkAnimacion.SetFloat("ValorY", -1);
                valorDelParametroX = BonkAnimacion.GetFloat("ValorX");
                valorDelParametroY = BonkAnimacion.GetFloat("ValorY");
            }
            else if (aiPath.velocity.y > 0 && Mathf.Abs(aiPath.velocity.x) < Mathf.Abs(aiPath.velocity.y))
            {
                BonkAnimacion.SetFloat("ValorX", 0);
                BonkAnimacion.SetFloat("ValorY", 1);
                valorDelParametroX = BonkAnimacion.GetFloat("ValorX");
                valorDelParametroY = BonkAnimacion.GetFloat("ValorY");
            }

        }

        else
        {
            BonkAnimacion.SetBool("SeMueve", false);
            BonkAnimacion.SetFloat("ValorX", valorDelParametroX);
            BonkAnimacion.SetFloat("ValorY", valorDelParametroY);
        }

    }



}
