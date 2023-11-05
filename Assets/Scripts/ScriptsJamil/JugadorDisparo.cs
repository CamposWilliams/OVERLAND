using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorDisparo : MonoBehaviour
{

    public GameObject bulletPrefab;
    public GameObject Arma;
    public GameObject puntoDeDisparo;

    public Camera c�mara;

    public Vector2 direction;


    void Start()
    {
        c�mara = Camera.main;
    }
    void Update()
    {
        Disparo();
        Apuntar();
    }

    void Apuntar()
    {
        Vector3 mousePosition = c�mara.ScreenToWorldPoint(Input.mousePosition);

        direction = mousePosition - Arma.transform.position;

        Arma.transform.up = direction.normalized;
    }

    void Disparo()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject obj = Instantiate(bulletPrefab);
            obj.transform.position = puntoDeDisparo.transform.position;
            obj.GetComponent<PlayerBullet>().direction = direction.normalized;
            
        }
    }
}
