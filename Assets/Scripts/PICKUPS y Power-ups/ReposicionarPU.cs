using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReposicionarPU : MonoBehaviour
{
   public GameObject Mike;
    Transform transformInicial;
    public GameObject[] cajas;
    public Transform MikeTrf;
    public bool pocionAzul;

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
        else if (Mike.GetComponent<MikeDisparo>().anguloConstante == 90 && pocionAzul)
        {
            transform.position = cajas[2].transform.position;
        }

        else if (Mike.GetComponent<MikeDisparo>().anguloConstante == 270 && pocionAzul)
        {
            transform.position = cajas[3].transform.position;
        }
        else
        {
            transform.position=transformInicial.position;
        }

    }
}
