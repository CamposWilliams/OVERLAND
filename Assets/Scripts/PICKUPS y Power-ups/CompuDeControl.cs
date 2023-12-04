using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompuDeControl : MonoBehaviour
{
   public int contador=0;
   public GameObject GasToxico;

    private void Update()
    {
        if (contador == 2)
        {
            Destroy(GasToxico);
        }
    }
}
