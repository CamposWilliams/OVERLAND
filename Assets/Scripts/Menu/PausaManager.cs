using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject pausaCanvas;

    private void Start()
    {
        pausaCanvas.gameObject.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // Pausa el tiempo en el juego
        pausaCanvas.gameObject.SetActive(true); // Activa el Canvas de pausa
    }

    void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Reanuda el tiempo en el juego
        pausaCanvas.gameObject.SetActive(false); // Desactiva el Canvas de pausa
    }
}