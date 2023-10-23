using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ExitButton : MonoBehaviour
{
    public Button salirboton;
    void Start()
    {
        salirboton.onClick.AddListener(Saliendo);
    }
    void Saliendo()
    {
        Debug.Log("Saliendo");
        Application.Quit();
    }

   
  
}
