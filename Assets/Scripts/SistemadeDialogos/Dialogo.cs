using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogo : MonoBehaviour
{
    [SerializeField] private GameObject IniciarDialogo;
    [SerializeField] private GameObject PanelDialogo;
    [SerializeField] private TMP_Text TextodeDialogo;
    [SerializeField, TextArea(4, 6)] private string[] líneasDialogo;
    private bool estaElJugadorEnRango;
    private bool haIniciadoElDialogo;
    private int indiceLinea;

    //variable nueva
    private float tiempoDeEscribir = 0.05f;
    void Update()
    {
        //if (estaElJugadorEnRango && Input.GetButtonDown("Fire1"))
        if (estaElJugadorEnRango && Input.GetKeyDown(KeyCode.E))
        {
            if (!haIniciadoElDialogo)
            {
                StartDialogo();
            }

        }
    }

    private void StartDialogo()
    {
        haIniciadoElDialogo = true;
        PanelDialogo.SetActive(true);
        IniciarDialogo.SetActive(false);
        indiceLinea = 0;

        StartCoroutine(MostrarLínea());
    }
    //para que los caracteres aparezcan por line, tipeo
    private IEnumerator MostrarLínea()
    {
        TextodeDialogo.text = string.Empty;

        foreach (char ch in líneasDialogo[indiceLinea])
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
