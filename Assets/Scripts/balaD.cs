using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balaD : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private float danio;

    private void Update()
    {
        transform.Translate(Vector2.up * velocidad * Time.deltaTime);
    }

}
