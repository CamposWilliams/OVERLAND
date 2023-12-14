using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CambiadorDeArmas : MonoBehaviour
{
    public Sprite[] imagenes; 
    private Image imagen;
    private int indiceActual;

    void Start()
    {
        imagen = GetComponent<Image>();
        //indiceActual = 0;
        //ActualizarImagen();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            CambiarImagen();
        }
    }

    void CambiarImagen()
    {
        if (imagenes.Length > 0)
        {
            indiceActual = (indiceActual + 1) % imagenes.Length;
            //Debug.Log(indiceActual);
            ActualizarImagen();
        }
        
    }

    void ActualizarImagen()
    {
        if (indiceActual >= 0 && indiceActual<4)
        {
            imagen.sprite = imagenes[indiceActual];
        }
        
    }
}