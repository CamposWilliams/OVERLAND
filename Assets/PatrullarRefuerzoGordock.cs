using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrullarRefuerzoGordock : MonoBehaviour
{
    [SerializeField] private Transform[] puntosMovimiento;
    public int indice;
    [SerializeField] private float velocidadMovimiento;
    public bool patrullar;
    private void Update()
    {
        patrullar = GetComponent<PatrullarGordock>().patrullar;
        Patrullaje();
    }
    void Patrullaje()
    {
        if (patrullar)
        {
            transform.position = Vector2.MoveTowards(transform.position, puntosMovimiento[indice].position, velocidadMovimiento * Time.deltaTime);

            if (Vector2.Distance(transform.position, puntosMovimiento[indice].position) < 0.1f)
            {
                //indice++;

                //if (indice == 4)
                //{
                //indice = 0;
                //}
                if (indice == puntosMovimiento.Length)
                {
                    indice = 0;
                }

            }
        }


    }
}
