using System.Collections;
using UnityEngine;
using Pathfinding;

public class EscaneoNavegacion : MonoBehaviour
{
    // Referencia al grafo de navegaci�n
    public AstarPath astarPath;

    // Capa para escanear despu�s del cambio
    public LayerMask capaEscaneo;

    void Start()
    {
        // Obt�n la referencia al componente AstarPath

        // Escanea inicialmente el grafo
        EscanearGrafo();
    }

    void EscanearGrafo()
    {
        
        // Escanea el grafo solo en las posiciones de la capa especificada
        GraphUpdateObject guo = new GraphUpdateObject(GetComponent<Collider2D>().bounds);
        guo.modifyTag = true;
        guo.setTag = (int)Mathf.Log(capaEscaneo.value, 2); // Obt�n el n�mero de capa

        // Aplica la actualizaci�n del grafo
        AstarPath.active.UpdateGraphs(guo);
       
    }

    // Llamado despu�s de cambiar la capa de la puerta
    public void RealizarEscaneo()
    {
        //Esta linea agregada 
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(EscanearDespuesDeTiempo());
        }
    }

    IEnumerator EscanearDespuesDeTiempo()
    {
        // Espera un breve per�odo para asegurarse de que la capa se haya actualizado completamente
        yield return new WaitForSeconds(0.1f);

        // Realiza el escaneo del grafo
        EscanearGrafo();
    }
}
