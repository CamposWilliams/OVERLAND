using UnityEngine;
using Pathfinding;

public class EvitarColisiones : MonoBehaviour
{
    public float distanciaEvitar = 2f;

    private Transform objetivo;
    private IAstarAI ai;

    void Start()
    {
        ai = GetComponent<IAstarAI>();
        objetivo = GameObject.FindGameObjectWithTag("Player").transform;  // Ajusta esto seg�n tu configuraci�n
    }

    void FixedUpdate()
    {
        // Verificar si hay enemigos cercanos
        Collider2D[] enemigosCercanos = Physics2D.OverlapCircleAll(transform.position, distanciaEvitar);

        foreach (Collider2D enemigo in enemigosCercanos)
        {
            if (enemigo.gameObject != gameObject)
            {
                // Obtener el componente IAstarAI del enemigo cercano
                IAstarAI aiEnemigo = enemigo.GetComponent<IAstarAI>();

                if (aiEnemigo != null)
                {
                    // Calcular una nueva posici�n de destino que evite al enemigo cercano
                    Vector3 direccionEvitar = (transform.position - enemigo.transform.position).normalized;
                    Vector3 nuevaPosicion = transform.position + direccionEvitar * distanciaEvitar;

                    // Establecer la nueva posici�n de destino
                    ai.destination = nuevaPosicion;
                }
            }
        }

        // Establecer la posici�n del jugador como destino principal
        ai.destination = objetivo.position;
    }
}
