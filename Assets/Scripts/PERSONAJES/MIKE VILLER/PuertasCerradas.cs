using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertasCerradas : MonoBehaviour
{
   public GameObject[] enemigosEnLaSala1;
   public GameObject[] enemigosEnLaSala2;
   public GameObject[] enemigosEnLaSala3;
   public GameObject[] enemigosEnLaSala4;

   public GameObject[] puertas;



    private void Update()
    {
        VerificarSala1();
        VerificarSala2();
        VerificarSala3();
        VerificarSala4();
    }

   void  VerificarSala1()
   {
        foreach(GameObject enemigos in enemigosEnLaSala1)
        {
            if (enemigos == null)
            {
                puertas[0].GetComponent<GestorDePuertas>().Confirmación = true;
            }
        }
   }
    void VerificarSala2()
    {
        foreach (GameObject enemigos in enemigosEnLaSala1)
        {
            if (enemigos == null)
            {
                puertas[1].GetComponent<GestorDePuertas>().Confirmación = true;
            }
        }
    }
    void VerificarSala3()
    {
        foreach (GameObject enemigos in enemigosEnLaSala1)
        {
            if (enemigos == null)
            {
                puertas[2].GetComponent<GestorDePuertas>().Confirmación = true;
            }
        }
    }
    void VerificarSala4()
    {
        foreach (GameObject enemigos in enemigosEnLaSala1)
        {
            if (enemigos == null)
            {
                puertas[3].GetComponent<GestorDePuertas>().Confirmación = true;
            }
        }
    }
}
