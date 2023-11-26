using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AreaDeSeguimiento : MonoBehaviour
{
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(GetComponentInParent<NavMeshAgent>().speed==0)
            {
                GetComponentInParent<Seguir>().navMeshAgent.speed = 1.5f;
                Debug.Log("entre");
            }
          
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponentInParent<Seguir>().navMeshAgent.speed = 0;
            Debug.Log("salí");
        }
     
    }
}
