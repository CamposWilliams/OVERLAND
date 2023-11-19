using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBoss : MonoBehaviour
{
    public Transform player; // Referencia al objeto del jugador
    public float speed = 3f; // Velocidad de movimiento del enemigo
    public float detectionRadius = 3f; // Radio de detección del jugador

    private Animator animator;
    private LifeBoss lifeScript; // Referencia al script LifeBoss

    void Start()
    {
        animator = GetComponent<Animator>();
        lifeScript = GetComponent<LifeBoss>(); // Obtener la referencia al script LifeBoss
    }

    void Update()
    {
        // Verificar si el enemigo está vivo antes de seguir al jugador
        if (lifeScript.IsAlive())
        {
            // Calcular la distancia entre el enemigo y el jugador
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            // Verificar si el jugador está dentro del radio de detección
            if (distanceToPlayer <= detectionRadius)
            {
                // Calcular la dirección hacia el jugador
                Vector2 direction = (player.position - transform.position).normalized;

                // Ajustar la dirección para limitar el movimiento a las cuatro direcciones principales
                float roundedX = Mathf.Round(direction.x);
                float roundedY = Mathf.Round(direction.y);

                // Mover al enemigo en la dirección ajustada
                transform.Translate(new Vector2(roundedX, roundedY) * speed * Time.deltaTime);

                // Actualizar las animaciones
                UpdateAnimations(new Vector2(roundedX, roundedY));
            }
        }
    }

    void UpdateAnimations(Vector2 direction)
    {
        // Actualizar las animaciones basadas en la dirección del movimiento
        if (direction != Vector2.zero)
        {
            animator.SetFloat("Horizontal", direction.x);
            animator.SetFloat("Vertical", direction.y);
        }

        // Establecer los parámetros de la animación para que el enemigo se detenga cuando no se está moviendo
        animator.SetFloat("Speed", direction.sqrMagnitude);
    }

    // Visualizar el radio de detección en el Editor de Unity
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}