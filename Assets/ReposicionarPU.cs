using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReposicionarPU : MonoBehaviour
{
    public Rigidbody2D MikeRb2D;
    Transform transformInicial;
    public GameObject[] cajas;
    public Transform Mike;

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
        

        if (MikeRb2D.velocity.x > 0)
        {

            transform.position = cajas[0].transform.position;
        }
       else if (MikeRb2D.velocity.x <0)
        {
            transform.position = cajas[1].transform.position;
        }
        else
        {
            transform.position = Mike.transform.position;
        }



    }
}
