using UnityEngine;
using TMPro;

public class ContadorDeBalas : MonoBehaviour
{
    public TextMeshProUGUI[] textMeshPros; // Arrastra y suelta los objetos TextMeshPro en el Inspector
    private int indiceActual = 0;

    void Start()
    {
        // Al inicio, desactiva todos los TextMeshProUGUI
        DesactivarTodosTextos();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
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

    void CambiarVisibilidadTextoSiguiente()
    {
        // Desactiva el texto actual
        if (indiceActual < textMeshPros.Length && textMeshPros[indiceActual] != null)
        {
            textMeshPros[indiceActual].enabled = false;
        }

        // Avanza al siguiente índice
        indiceActual = (indiceActual + 1) % textMeshPros.Length;

        // Activa el siguiente texto
        if (textMeshPros[indiceActual] != null)
        {
            textMeshPros[indiceActual].enabled = true;
        }
    }
}