using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PatrullarBonk : MonoBehaviour
{
   
    
  
    public bool volviendoAlPunto;
    public float distance;
    public bool patrullar;
    [SerializeField] private Transform[] puntosMovimiento;



    private void Update()
    {

        //Debug.Log("Funciona");
        distance = Vector2.Distance(transform.position, puntosMovimiento[0].position);
        VolverAlPunto();

    }
    void VolverAlPunto()
    {
      
        if (volviendoAlPunto)
        {

            if (Vector2.Distance(transform.position, puntosMovimiento[0].position) <0.005f)
            {
                volviendoAlPunto = false;
                Debug.Log("HolaMundo");
                //GetComponent<AIPath>().enabled = false;
                GetComponent<AIDestinationSetter>().enabled=false;
                patrullar = true;
                
            }
            


        }
    }

   

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            patrullar=false;
            volviendoAlPunto = false;
            GetComponent<AIDestinationSetter>().enabled = true;
            GetComponent<SeguirAstarBonk>().MikeTrf = GameObject.Find("Mike").transform;
            GetComponent<AIDestinationSetter>().target = GameObject.Find("Mike").transform;
        }
         

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //GetComponent<AIPath>().enabled = true;
            volviendoAlPunto = true;
            GetComponent<SeguirAstarBonk>().MikeTrf = puntosMovimiento[0];
            GetComponent<AIDestinationSetter>().target = puntosMovimiento[0];
        }


    }

}