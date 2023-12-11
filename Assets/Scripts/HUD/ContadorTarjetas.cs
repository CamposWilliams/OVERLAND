using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ContadorTarjetas : MonoBehaviour
{
    public TextMeshProUGUI textoScore;
    private int score = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tarjeta1") || collision.CompareTag("Tarjeta2"))
        {
           
            score++;

           
            ActualizarTextoScore();

            
            Destroy(collision.gameObject);
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