using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

  
    
        public bool destruido = false;
        public float tiempoAbierto;
        public float MaximoTiempo = 1.0f; // Tiempo en segundos para reaparecer la puerta
        private Renderer doorRenderer;


        private void Start()
        {
            doorRenderer = GetComponent<Renderer>();
        }

        private void Update()
        {
            if (destruido)
            {
                tiempoAbierto += Time.deltaTime;

                if (tiempoAbierto >= MaximoTiempo)
                {
                    destruido = false;
                    tiempoAbierto = 0;
                    // Reactivar la puerta
                    doorRenderer.enabled = true;
                    // Opcionalmente, puedes volver a habilitar el Collider si la puerta tiene uno.
                    Collider2D doorCollider = GetComponent<Collider2D>();
                    if (doorCollider != null)
                    {
                        doorCollider.enabled = true;
                    }
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {

                destruido = true;
                doorRenderer.enabled = false;

                Collider2D doorCollider = GetComponent<Collider2D>();
                if (doorCollider != null)
                {
                    doorCollider.enabled = false;
                }
            }
        }
    

}
