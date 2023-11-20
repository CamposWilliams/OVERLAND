using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public Button boton;
    void Start()
    {
        boton.onClick.AddListener(StartGame);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    

}
