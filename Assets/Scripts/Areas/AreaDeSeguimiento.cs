using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AreaDeSeguimiento : MonoBehaviour
{
    public AIPath aiPath;
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            aiPath.enabled = true;
        }
          
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            aiPath.enabled = false;

        }

    }
}
