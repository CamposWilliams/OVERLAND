using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarTrigger : MonoBehaviour
{
  public Collider2D colliderBonk;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (colliderBonk != null)
        {
            if (collision.CompareTag("Enemigo1"))
            {
                Debug.Log("Entre");
                colliderBonk.isTrigger = true;
            }
        }
      
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(colliderBonk != null)
        {
            if (collision.CompareTag("Enemigo1"))
            {
                colliderBonk.isTrigger =false;

            }
        }
       
    }
}
