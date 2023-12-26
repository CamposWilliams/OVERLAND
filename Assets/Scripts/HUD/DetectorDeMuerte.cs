using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DetectorDeMuerte : MonoBehaviour
{
   
    
        //public string NombreScena = "NombreDeTuEscena"; 


        //Detecta cuando el Game object se destruye
        private void OnDestroy()
        {
            SceneManager.LoadScene(7);
        }
}

