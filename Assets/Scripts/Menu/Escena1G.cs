
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Escena1G : MonoBehaviour
{
    // Start is called before the first frame update


    public Button boton;
    // El bot�n que activar� el cambio de escena

    private void Start()
    {
        boton.onClick.AddListener(Juegar);
    }

    // M�todo para volver a una escena espec�fica
    public void Juegar()
    {
        SceneManager.LoadScene(1);
    }
}

