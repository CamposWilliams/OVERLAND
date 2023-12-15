using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogo : MonoBehaviour
{
    [SerializeField] private GameObject IniciarDialogo; //collider is trigger
    [SerializeField] private GameObject PanelDialogo; //canvas
    [SerializeField] private TMP_Text TextodeDialogo; // la fuente escogida
    [SerializeField, TextArea(4, 6)] private string[] lineasDialogo;
    private bool estaElJugadorEnRango;
    private bool haIniciadoElDialogo;
    private int indiceLinea;

    //variable nueva controla el tiempo del tipeo 
    private float tiempoDeEscribir = 0.02f;
    void Update()
    {
        //if (estaElJugadorEnRango && Input.GetButtonDown("Fire1"))
        if (estaElJugadorEnRango && Input.GetKeyDown(KeyCode.E))
        {
            if (!haIniciadoElDialogo)
            {
                StartDialogo();
            }
            //agrgado
            else if(TextodeDialogo.text == lineasDialogo[indiceLinea])
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
        //detener el tiempo
        Time.timeScale = 0f;

        StartCoroutine(MostrarLínea());
    }

    private void SiguienteLineaDeDialogo() 
    {
        indiceLinea++;
        if(indiceLinea < lineasDialogo.Length)
        {
            StartCoroutine(MostrarLínea());
        }
        else 
        {
            haIniciadoElDialogo=false;
            PanelDialogo.SetActive(false );
            IniciarDialogo.SetActive(true);
            //
            Time.timeScale = 1f;
        }
    }
    //para que los caracteres aparezcan por line, tipeo
    private IEnumerator MostrarLínea()
    {
        TextodeDialogo.text = string.Empty;

        foreach (char ch in lineasDialogo[indiceLinea])
        {
            TextodeDialogo.text += ch;
            //yield return new WaitForSeconds(tiempoDeEscribir);
            //para que las lineas del dialogo no sea afectado por timeScale
            yield return new WaitForSecondsRealtime(tiempoDeEscribir);
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
