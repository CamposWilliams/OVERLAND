using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrullarRefuerzoVomet : MonoBehaviour
{
    [SerializeField] private Transform[] puntosMovimiento;
    public int indice;
    [SerializeField] private float velocidadMovimiento;
    public bool patrullar;
    private void Update()
    {
        patrullar = GetComponent<PatrullarVomet>().patrullar;
        Patrullaje();
    }
    void Patrullaje()
    {
        if (patrullar)
        {
            transform.position = Vector2.MoveTowards(transform.position, puntosMovimiento[indice].position, velocidadMovimiento * Time.deltaTime);

            if (Vector2.Distance(transform.position, puntosMovimiento[indice].position) < 0.1f)
            {
                indice++;

                if (indice == puntosMovimiento.Length)
                {
                    indice = 0;
                }

            }
        }


    }
}
