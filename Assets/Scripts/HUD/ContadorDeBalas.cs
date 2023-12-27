using UnityEngine;
using TMPro;

public class ContadorDeBalas : MonoBehaviour
{
    public TextMeshProUGUI[] textMeshPros;
    private int indiceActual = 0;
    GameObject Mike;
    GameObject Guardador;
    private void Awake()
    {
        Mike=GameObject.Find("Mike");
        Guardador = GameObject.Find("GuardaDatosEntreEscena");
    }

    void Start()
    {
       
        DesactivarTodosTextos();

        ActivarTexto(Guardador.GetComponent<GuardaDatos>().armaActual);
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
        if (indice <= textMeshPros.Length && indice>=0)
        {
            Debug.Log("Actualice");
            textMeshPros[indice].enabled = true;
        }
      
    }

    void CambiarVisibilidadTextoSiguiente()
    {

        if ((int)Mike.GetComponent<JugadorDisparo>().CambioArma >=0 && (int)Mike.GetComponent<JugadorDisparo>().CambioArma <=textMeshPros.Length )
        {
            DesactivarTodosTextos();

            textMeshPros[(int)Mike.GetComponent<JugadorDisparo>().CambioArma].enabled = true;

        }

    }
}
