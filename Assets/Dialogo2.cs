using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Dialogo2 : MonoBehaviour
{
    [SerializeField] private GameObject IniciarDialogo; //collider is trigger
    [SerializeField] private GameObject PanelDialogo; //canvas
    [SerializeField] private TMP_Text TextodeDialogo; // la fuente escogida
    [SerializeField, TextArea(4, 6)] private string[] lineasDialogo;
    private bool estaElJugadorEnRango;
    private bool haIniciadoElDialogo;
    private bool haMostradoDialogo; // Nueva variable para verificar si el diálogo ya se ha mostrado
    private int indiceLinea;

    //variable nueva controla el tiempo del tipeo 
    private float tiempoDeEscribir = 0.1f;
    void Update()
    {
        if (estaElJugadorEnRango && !haMostradoDialogo) // Solo inicia el diálogo si no se ha mostrado antes
        {
            if (!haIniciadoElDialogo)
            {
                StartDialogo();
            }
            else if (TextodeDialogo.text == lineasDialogo[indiceLinea])
            {
                SiguienteLineaDeDialogo();
            }
        }
    }

    private void StartDialogo()
    {
        haIniciadoElDialogo = true;
        PanelDialogo.SetActive(true);
        IniciarDialogo.SetActive(false);
        indiceLinea = 0;
        _ = StartCoroutine(MostrarLínea());
    }

    private void SiguienteLineaDeDialogo()
    {
        indiceLinea++;
        if (indiceLinea < lineasDialogo.Length)
        {
            StartCoroutine(MostrarLínea());
        }
        else
        {
            haIniciadoElDialogo = false;
            haMostradoDialogo = true; // Marca que el diálogo ya se ha mostrado
            PanelDialogo.SetActive(false);
            IniciarDialogo.SetActive(true);
        }
    }

    private IEnumerator MostrarLínea()
    {
        TextodeDialogo.text = string.Empty;

        foreach (char ch in lineasDialogo[indiceLinea])
        {
            TextodeDialogo.text += ch;
            yield return new WaitForSeconds(tiempoDeEscribir);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            estaElJugadorEnRango = true;
            IniciarDialogo.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            estaElJugadorEnRango = false;
            IniciarDialogo.SetActive(false);
        }
    }
}