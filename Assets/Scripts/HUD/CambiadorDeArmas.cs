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

        // Cambiar de arma con la rueda del mouse
        CambiarArmaConRuedaDelMouse();
        ActualizarImagen();
    }

    void CambiarImagen()
    {
        if (imagenes.Length > 0)
        {
            indiceActual = (indiceActual + 1) % imagenes.Length;        
        }
    }

    void CambiarArmaConRuedaDelMouse()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0f && (indiceActual < imagenes.Length))
        {
            // Desplazamiento hacia arriba en la ruedita del mouse
            indiceActual = (indiceActual + 1) % imagenes.Length;
            ActualizarImagen();

        }
        else if (scroll < 0f && (indiceActual < imagenes.Length))
        {
            // Desplazamiento hacia abajo en la ruedita del mouse
            indiceActual = (indiceActual - 1 + imagenes.Length) % imagenes.Length;
            ActualizarImagen();
        }
    }

    void ActualizarImagen()
    {
        if (indiceActual >= 0 && indiceActual < imagenes.Length)
        {
            imagen.sprite = imagenes[indiceActual];
        }
    }
}
