using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
//bibliotecas de UI

public class Salir : MonoBehaviour
{
   
   //Busca el componente boton
     public Button botonDeSalir;


   
    void Start()
    {
        //LLAMA AL METODO salir applicacion
        botonDeSalir.onClick.AddListener(SalirAplicacion);
    }
    void SalirAplicacion()
    {
        // Este método se llamará cuando se haga clic en el botón
        Debug.Log("Saliendo...");
        Application.Quit();
    }
}
