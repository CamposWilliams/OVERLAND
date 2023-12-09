using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlDeFrames : MonoBehaviour
{
    public GameObject[] frames; // Asigna tus canvas UI en el inspector de Unity
    private int currentFrame = 0;

    void Start()
    {
        // Activa el primer canvas (Background) y desactiva los demás
        for (int i = 0; i < frames.Length; i++)
        {
            frames[i].SetActive(i == currentFrame);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Desactiva el canvas actual
            frames[currentFrame].SetActive(false);

            // Incrementa currentFrame o vuelve a 0 si es el último frame
            currentFrame = (currentFrame + 1) % frames.Length;

            // Si currentFrame es 0 después de incrementarlo, cambia a la escena "Nivel 1"
            if (currentFrame == 0)
            {
                SceneManager.LoadScene("NIVEL1");
            }
            else
            {
                // Activa el siguiente canvas
                frames[currentFrame].SetActive(true);
            }
        }
    }
}