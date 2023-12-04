using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReposicionarPU : MonoBehaviour
{
   public GameObject Mike;
    Transform transformInicial;
    public GameObject[] cajas;
    public Transform MikeTrf;

    private void Start()
    {
        transformInicial = transform;
    }
    private void Update()
    {
        Reposicionar();
    }

    void Reposicionar()
    {
        

        if (Mike.GetComponent<MikeDisparo>().anguloConstante==180)
        {

            transform.position = cajas[0].transform.position;
        }
       else if (Mike.GetComponent<MikeDisparo>().anguloConstante ==0)
        {
            transform.position = cajas[1].transform.position;
        }
        else
        {
            transform.position = MikeTrf.transform.position;
        }



    }
}
