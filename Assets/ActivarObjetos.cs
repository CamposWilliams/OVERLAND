using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarObjetos : MonoBehaviour
{
    public List<GameObject> municion = new List<GameObject>();
    public List<GameObject> botiquin = new List<GameObject>();
    float tiempoDeEspera = 6f;
    public List<Transform> municionTrf = new List<Transform>();
    public List<Transform> botiquinTrf = new List<Transform>();

    float time;
    float time2;
    float contador;
    float contador2;
    void Update()
    {
        ReactivarMuniciones();
        ReactivarBotiquines();
    }

    void ReactivarMuniciones()
    {
        time += Time.deltaTime;
        if (time >= 6 && contador == 0)
        {

            if (municion.Count > 0 && municionTrf.Count > 0)
            {
                StartCoroutine(ReactivarConRetrasoMunicion(municion, municionTrf));
                contador++;
            }
            time = 0;
        }
    }

    void ReactivarBotiquines()
    {
        time2 += Time.deltaTime;
        if(time2>=6 && contador2 == 0)
        {
            if (botiquin.Count > 0 && botiquinTrf.Count > 0)
            {
                StartCoroutine(ReactivarConRetrasoBotiquin(botiquin, botiquinTrf));
                contador2++;
            }
            time2 = 0;
        }

      
    }

    IEnumerator ReactivarConRetrasoMunicion(List<GameObject> objetos, List<Transform> posiciones)
    {
        //Debug.Log("Llamando a ReactivarBotiquines");
        yield return null;

        for (int i = 0; i < Mathf.Min(objetos.Count, posiciones.Count); i++)
        {
            GameObject obj = objetos[i];
            Transform trf = posiciones[i];

            if (!obj.activeSelf)
            {
                // Activar el objeto
                obj.SetActive(true);

                // Establecer la posición del objeto según la posición guardada
                obj.transform.position = trf.position;

                // Activar el Collider del objeto
                Collider2D collider = obj.GetComponent<Collider2D>();
                if (collider != null)
                {
                    collider.enabled = true;
                }

                // Activar el SpriteRenderer del objeto
                SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    spriteRenderer.enabled = true;
                }
                contador = 0;
                municion.Clear();
                municionTrf.Clear();

                // Imprimir la posición del objeto en la consola
                //Debug.Log($"Objeto reactivado en la posición: {obj.transform.position}");
            }
        }
    }



    IEnumerator ReactivarConRetrasoBotiquin(List<GameObject> objetos, List<Transform> posiciones)
    {
        //Debug.Log("Llamando a ReactivarBotiquines");
        yield return null;

        for (int i = 0; i < Mathf.Min(objetos.Count, posiciones.Count); i++)
        {
            GameObject obj = objetos[i];
            Transform trf = posiciones[i];

            if (!obj.activeSelf)
            {
                // Activar el objeto
                obj.SetActive(true);

                // Establecer la posición del objeto según la posición guardada
                obj.transform.position = trf.position;

                // Activar el Collider del objeto
                Collider2D collider = obj.GetComponent<Collider2D>();
                if (collider != null)
                {
                    collider.enabled = true;
                }

                // Activar el SpriteRenderer del objeto
                SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    spriteRenderer.enabled = true;
                }
              
                contador2 = 0;
                botiquin.Clear();
                botiquinTrf.Clear();
                // Imprimir la posición del objeto en la consola
                //Debug.Log($"Objeto reactivado en la posición: {obj.transform.position}");
            }
        }
    }

}
