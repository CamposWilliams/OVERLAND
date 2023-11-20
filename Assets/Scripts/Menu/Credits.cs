using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public Button boton3;
    void Start()
    {
        boton3.onClick.AddListener(creditos);
    }

    
    public void creditos()
    {
        SceneManager.LoadScene(4);
    }
}
