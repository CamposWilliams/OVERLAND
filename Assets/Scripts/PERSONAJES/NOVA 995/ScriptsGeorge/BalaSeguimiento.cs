using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaSeguimiento : MonoBehaviour
{
    private Transform objetivo; // Referencia al transform del personaje
    float velocidad = 3.5f; // Velocidad de seguimiento de la bala
    float time;

    void Start()
    {
        BuscarObjetivo();
    }

    void Update()
    {
        time += Time.deltaTime;

        if (objetivo != null && time < 1.5f)
        {
            // Calcula la dirección hacia el objetivo
            Vector3 direccion = objetivo.position - transform.position;
            direccion.Normalize(); // Normaliza para obtener un vector de dirección unitario

            // Mueve la bala hacia el objetivo
            transform.Translate(direccion * velocidad * Time.deltaTime);
        }

        else
        {

            if (time <  1.5f)
            {
                BuscarObjetivo(); // Si el objetivo no está asignado, intenta buscarlo nuevamente
            }

            else
            {
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            }
            
        }

        
    }

    void BuscarObjetivo()
    {
        // Busca el objetivo en la escena (puede personalizarse según tus necesidades)
        GameObject[] objetivos = GameObject.FindGameObjectsWithTag("Player");

        if (objetivos.Length > 0)
        {
            // Asigna el primer objeto encontrado como objetivo (puedes ajustar esta lógica)
            objetivo = objetivos[0].transform;
        }
    }
}
