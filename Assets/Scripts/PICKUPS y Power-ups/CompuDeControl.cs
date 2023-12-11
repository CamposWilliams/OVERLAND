using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CompuDeControl : MonoBehaviour
{
    public int contador = 0;
    public GameObject GasToxico;
    public TextMeshProUGUI textoContador;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
        }
    }

    private void Update()
    {
        
        if (Input.GetKey("e") && contador >= 2)
        {
            Destroy(GasToxico);
            contador = 0;
            TarjetaTocada();
        }
    }

    public void TarjetaTocada()
    {
        contador++;
        ActualizarTextoContador();
    }

    void ActualizarTextoContador()
    {
        if (textoContador != null)
        {
            textoContador.text = "Tarjetas: " + contador.ToString();
        }
    }
}
