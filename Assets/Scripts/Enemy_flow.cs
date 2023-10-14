using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_flow : MonoBehaviour
{
    public Transform jugador; // El transform del jugador que el enemigo debe seguir.
    public float velocidad = 5f; // Velocidad a la que el enemigo seguirá al jugador.

    private void Update()
    {
        // Calcula la dirección hacia la que debe moverse el enemigo para seguir al jugador.
        Vector3 direccion = (jugador.position - transform.position).normalized;

        
        // Mueve al enemigo hacia el jugador.
        transform.Translate(direccion * velocidad * Time.deltaTime);
    }
}
