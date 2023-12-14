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
        indiceActual = 0;
        ActualizarImagen();
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
        indiceActual = (indiceActual + 1) % imagenes.Length;
        ActualizarImagen();
    }

    void ActualizarImagen()
    {
        imagen.sprite = imagenes[indiceActual];
    }
}