using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBoss : MonoBehaviour
{
    public Transform player; // Referencia al objeto del jugador
    public float speed = 3f; // Velocidad de movimiento del enemigo
    public float detectionRadius = 9f; // Radio de detección del jugador

    private Animator animator;
    private Vector2 lastDirection;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Calcula la distancia entre el enemigo y el jugador
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRadius)
        {
            // Calcula la dirección hacia el jugador
            Vector2 direction = (player.position - transform.position).normalized;

            // Mueve al enemigo en la dirección del jugador
            transform.Translate(direction * speed * Time.deltaTime);

            // Actualiza las animaciones
            UpdateAnimations(direction);
        }
    }

    void UpdateAnimations(Vector2 direction)
    {
        // Actualiza las animaciones basadas en la dirección del movimiento
        if (direction != Vector2.zero)
        {
            lastDirection = direction;
            animator.SetFloat("Horizontal", direction.x);
            animator.SetFloat("Vertical", direction.y);
        }

        // Establece los parámetros de la animación para que el enemigo se detenga cuando no se está moviendo
        animator.SetFloat("Speed", direction.sqrMagnitude);
    }


}
