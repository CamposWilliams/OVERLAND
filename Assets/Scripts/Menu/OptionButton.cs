using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionButton : MonoBehaviour
{
    public Button boton2;
    void Start()
    {
        boton2.onClick.AddListener(Option);
    }
    public void Option()
    {
        SceneManager.LoadScene(1);
    }


}
