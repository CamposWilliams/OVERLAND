using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasDesacivador : MonoBehaviour
{
    // Referencia al script que quieres desactivar
    public MonoBehaviour scriptToDisable;

    void Start()
    {
        // Desactiva el script
        scriptToDisable.enabled = false;
    }
}
