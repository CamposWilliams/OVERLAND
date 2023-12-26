using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ContadorTarjetas : MonoBehaviour
{
    public TextMeshProUGUI textoScore;
    private int score = 0;
    int contador = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tarjeta1") || collision.CompareTag("Tarjeta2"))
        {
           
            score++;

           
            ActualizarTextoScore();

            
            Destroy(collision.gameObject);
        }
    }
    private void Update()
    {
        if(GameObject.Find("COMPUTADORA DE CONTROL")!= null)
        {
            if (GameObject.Find("COMPUTADORA DE CONTROL").GetComponent<CompuDeControl>().ponerContadorDeTarjetasEnCero && Input.GetKeyDown("e"))
            {
                contador++;
                if (GameObject.Find("COMPUTADORA DE CONTROL").GetComponent<CompuDeControl>().ponerContadorDeTarjetasEnCero && Input.GetKeyDown("e") && contador == 1)
                    textoScore.text = "x" + 0.ToString();
            }
        }
       
    }
    void ActualizarTextoScore()
    {
        if (textoScore != null)
        {
            textoScore.text = "x" + score.ToString();
        }

       
    }
}