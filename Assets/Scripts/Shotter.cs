using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotter : MonoBehaviour
{
    [SerializeField] private Transform controlDisparo;

    [SerializeField] private GameObject bullet;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Disparar();
        }
    }

        private void Disparar()
        {
        Instantiate(bullet, controlDisparo.position, controlDisparo.rotation);
        }

        
    
}
