using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputadoraDeControl : MonoBehaviour
{
    // Declara una variable privada de tipo bool llamada anularDanio y la inicializa con un valor de false
    // Esta variable se utiliza para rastrear si se ha activado la anulación del daño y la destrucción
    private bool anularDanio = false;

    // Método que llama que activa la anulacion del danio
    public void ActivarAnulacion()
    {
        anularDanio = true;
    }

    // Método OnTriggerEnter2D que se llama automáticamente cuando otro objeto entra en el collider del objeto actual
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Comprueba si el objeto que ha entrado en el collider con el tag Player     
        if (other.CompareTag("Player"))
        {
            if (anularDanio)
            {
                // Si el tag es Player entonces restablece el daño a cero
                ZonaContaminada zonaContaminada = GetComponent<ZonaContaminada>();
                if (zonaContaminada != null)
                {
                    zonaContaminada.danio = 0;
                }
            }
        }
    }
}
