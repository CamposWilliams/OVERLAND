using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaContaminada : MonoBehaviour
{
    // Declara una variable p�blica de tipo int llamada danio 
    // Esta variable representa el numero de da�o que se aplicar� al player
    public int danio = 5;
    // Declara una variable privada de tipo bool llamada anularDanio, Variable para rastrear si se ha activado la anulaci�n del da�o
    private bool anularDanio = false;

    // M�todo p�blico llamado ActivarAnulacion que cambia el valor de anularDanio a true(Verdadero)
    public void ActivarAnulacion()
    {
        anularDanio = true;
    }

    // M�todo OnTriggerEnter2D cuando un objeto entra en el collider del objeto actual
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Comprueba si el objeto que ha entrado en el collider tiene el tag Player
        if (other.CompareTag("Player"))
        {
            // Si la etiqueta es "Player" y anularDanio es false, entonces resta puntos de vida al jugador
            if (!anularDanio)
            {
                // Restar da�o puntos de vida al jugador
                PlayerVida jugador = other.GetComponent<PlayerVida>();
                if (jugador != null)
                {
                    jugador.RestarVida(danio);
                }
            }
        }
    }
}
