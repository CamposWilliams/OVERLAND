using UnityEngine;
using TMPro;

public class ContadorDeBalas : MonoBehaviour
{
    public TextMeshProUGUI[] textMeshPros;
    private int indiceActual = 0;

    void Start()
    {
        DesactivarTodosTextos();
        ActivarTexto(0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            CambiarVisibilidadTextoSiguiente();
        }

        // Detectar el scroll del mouse
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0f)
        {
            // Cambiar la visibilidad del texto al hacer scroll
            CambiarVisibilidadTextoSiguiente();
        }
    }

    void DesactivarTodosTextos()
    {
        foreach (TextMeshProUGUI textMeshPro in textMeshPros)
        {
            if (textMeshPro != null)
            {
                textMeshPro.enabled = false;
            }
        }
    }

    void ActivarTexto(int indice)
    {
        if (indice < textMeshPros.Length && textMeshPros[indice] != null)
        {
            textMeshPros[indice].enabled = true;
        }
    }

    void CambiarVisibilidadTextoSiguiente()
    {
        // Desactivar el texto actual
        if (indiceActual < textMeshPros.Length && textMeshPros[indiceActual] != null)
        {
            textMeshPros[indiceActual].enabled = false;
        }

        // Avanzar al siguiente índice
        indiceActual = (indiceActual + 1) % textMeshPros.Length;

        // Activar el siguiente texto
        if (textMeshPros[indiceActual] != null)
        {
            textMeshPros[indiceActual].enabled = true;
        }
    }
}
