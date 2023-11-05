using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVida : MonoBehaviour
{
    public int vidaInicial = 10;
    private int vidaActual;

    void Start()
    {
        vidaActual = vidaInicial;
    }

    public void RestarVida(int cantidad)
    {
        vidaActual -= cantidad;

        if (vidaActual <= 0)
        {
            // Destruir el objeto del jugador
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Vida restante: " + vidaActual);
        }
    }
}
