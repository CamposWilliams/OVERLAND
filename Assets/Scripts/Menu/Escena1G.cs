
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Escena1G : MonoBehaviour
{
    // Start is called before the first frame update


    public Button boton;
    // El botón que activará el cambio de escena

    private void Start()
    {
        boton.onClick.AddListener(Juegar);
    }

    // Método para volver a una escena específica
    public void Juegar()
    {
        SceneManager.LoadScene(1);
    }
}

