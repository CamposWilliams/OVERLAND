using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DetectorDeMuerte : MonoBehaviour
{
    GameObject Mike;
    float time;
    //public string NombreScena = "NombreDeTuEscena"; 
    private void Awake()
    {
        Mike = GameObject.Find("Mike");
    }

    private void Update()
    {
        if (Mike == null)
        {
            SceneManager.LoadScene(7);
        }

        if(gameObject.GetComponent<LifeBoss>().currentHealth==0)
        {
            time += Time.deltaTime;

            if (time >= 3f)
            {
                SceneManager.LoadScene(6);
            }

        }
    }
}

