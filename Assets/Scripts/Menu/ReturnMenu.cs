using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReturnMenu : MonoBehaviour
{
    public Button boton4;
    void Start()
    {
        boton4.onClick.AddListener(creditos);
    }


    public void creditos()
    {
        SceneManager.LoadScene(3);
    }
}
