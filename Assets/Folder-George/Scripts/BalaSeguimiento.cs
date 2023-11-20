using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaSeguimiento : MonoBehaviour
{
    private Transform objetivo; // Referencia al transform del personaje
    public float velocidad = 5f; // Velocidad de seguimiento de la bala

    void Start()
    {
        BuscarObjetivo();
    }

    void Update()
    {
        if (objetivo != null)
        {
            // Calcula la direcci�n hacia el objetivo
            Vector3 direccion = objetivo.position - transform.position;
            direccion.Normalize(); // Normaliza para obtener un vector de direcci�n unitario

            // Mueve la bala hacia el objetivo
            transform.Translate(direccion * velocidad * Time.deltaTime);
        }
        else
        {
            BuscarObjetivo(); // Si el objetivo no est� asignado, intenta buscarlo nuevamente
        }
    }

    void BuscarObjetivo()
    {
        // Busca el objetivo en la escena (puede personalizarse seg�n tus necesidades)
        GameObject[] objetivos = GameObject.FindGameObjectsWithTag("Player");

        if (objetivos.Length > 0)
        {
            // Asigna el primer objeto encontrado como objetivo (puedes ajustar esta l�gica)
            objetivo = objetivos[0].transform;
        }
    }
}
