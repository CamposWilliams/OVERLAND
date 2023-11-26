using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Seguir : MonoBehaviour
{
  
    public NavMeshAgent navMeshAgent;
    Animator BonkAnimacion;
    public Transform MikeTrf;
    float valorDelParametroX;
    float valorDelParametroY;
    

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = 0;
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
        BonkAnimacion = GetComponent<Animator>();

    }


    private void Update()
    {
        navMeshAgent.updatePosition = false;
        SeguimientoDeAnimacion();
        AtaqueAnimacion();

    }

    private void FixedUpdate()
    {
        navMeshAgent.updatePosition = true;

        navMeshAgent.SetDestination(MikeTrf.position); 
       
    }

    void AtaqueAnimacion()
    {

    }


    void SeguimientoDeAnimacion()
    {
        if (navMeshAgent.speed != 0)
        {
            BonkAnimacion.SetBool("SeMueve", true);
            
            if (navMeshAgent.velocity.x >0 && Mathf.Abs(navMeshAgent.velocity.x)> Mathf.Abs(navMeshAgent.velocity.y))
            {
                //Debug.Log("Derecha");
                BonkAnimacion.SetFloat("ValorY", 0);
                BonkAnimacion.SetFloat("ValorX", 1);
                valorDelParametroX = BonkAnimacion.GetFloat("ValorX");
                valorDelParametroY = BonkAnimacion.GetFloat("ValorY");
            }

            else if (navMeshAgent.velocity.x< 0 && Mathf.Abs(navMeshAgent.velocity.x) > Mathf.Abs(navMeshAgent.velocity.y))
            {
                //Debug.Log("Izquierda");
                BonkAnimacion.SetFloat("ValorY", 0);
                BonkAnimacion.SetFloat("ValorX", -1);
                valorDelParametroX = BonkAnimacion.GetFloat("ValorX");
                valorDelParametroY = BonkAnimacion.GetFloat("ValorY");
            }

            else if (navMeshAgent.velocity.y < 0 && Mathf.Abs(navMeshAgent.velocity.x)<  Mathf.Abs(navMeshAgent.velocity.y))
            {
                BonkAnimacion.SetFloat("ValorX", 0);
                BonkAnimacion.SetFloat("ValorY", -1);
                valorDelParametroX = BonkAnimacion.GetFloat("ValorX");
                valorDelParametroY = BonkAnimacion.GetFloat("ValorY");
            }
            else if (navMeshAgent.velocity.y > 0 && Mathf.Abs(navMeshAgent.velocity.x) < Mathf.Abs(navMeshAgent.velocity.y))
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
