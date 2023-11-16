using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TarjetaController : MonoBehaviour
{
    public bool tarjetaRecogida = false; // Variable para rastrear si la tarjeta ha sido recogida

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Recolectar la tarjeta
            RecogerTarjeta();

            // Verificar si se han recolectado ambas tarjetas y activar la anulación del daño y la destrucción
            if (tarjetaRecogida && other.GetComponent<ComputadoraDeControl>() != null)
            {
                other.GetComponent<ComputadoraDeControl>().ActivarAnulacion();
            }
        }
    }

    private void RecogerTarjeta()
    {
        // Desactivar el objeto de la tarjeta
        gameObject.SetActive(false);
        tarjetaRecogida = true;
    }
}
