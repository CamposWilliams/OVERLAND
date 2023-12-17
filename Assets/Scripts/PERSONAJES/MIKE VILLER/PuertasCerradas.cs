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
        VerificarSala(enemigosEnLaSala1, puertas[0]);
        VerificarSala(enemigosEnLaSala2, puertas[1]);
        VerificarSala(enemigosEnLaSala3, puertas[2]);
        VerificarSala(enemigosEnLaSala4, puertas[3]);
    }

    void VerificarSala(GameObject[] enemigosEnLaSala, GameObject puerta)
    {
        bool todosMuertos = true;

        foreach (GameObject enemigo in enemigosEnLaSala)
        {
            if (enemigo != null)
            {
                todosMuertos = false;
                break; // Si se encuentra al menos un enemigo vivo, no es necesario seguir verificando.
            }
        }

        // Cambiar Confirmaci�n solo si todos los enemigos est�n muertos.
        puerta.GetComponent<GestorDePuertas>().Confirmaci�n = todosMuertos;
    }
}

