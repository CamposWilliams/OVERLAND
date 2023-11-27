using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoBoss : MonoBehaviour
{
    public GameObject bulletPrefabFlow;
    public GameObject bulletPrefabDerecha;
    public GameObject bulletPrefabIzquierda;
    public GameObject bulletPrefabAbajo;
    public GameObject bulletPrefabArriba;
    //
    public GameObject bulletPrefabDiaDA;
    public GameObject bulletPrefabDiaDAB;
    public GameObject bulletPrefabDiaIA;
    public GameObject bulletPrefabDiaIAB;

    public Transform PointDerecha;
    public Transform PointIzquierda;
    public Transform PointAbajo;
    public Transform PointArriba;
    public Transform PointDia_De_Ar;
    public Transform PointDia_Iz_Ar;
    public Transform PointDia_De_Aba;
    public Transform PointDia_Iz_Aba;

    public int Speed = 10;





    /* void Update()
     {
         Shoot();
     }

     void Shoot()
     {
         timer += Time.deltaTime;
         if (timer >= maxTimer)
         {
             GameObject obj = Instantiate(bulletPrefab);
             obj.transform.position = transform.position;
             Destroy(obj, 3.0f);
             timer = 0;
         }

     }
    */

    void Awake()
    {
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            int count = 0;
            GameObject obj = null;
            while (count < 13)
            {


                if (count % 13 == 0)
                {
                    obj = Instantiate(bulletPrefabFlow); // Primer tipo de disparo (una sola bala)
                }
                else if (count % 4 == 0)
                {
                    //DERECHA
                    GameObject bullet01 = Instantiate(bulletPrefabDerecha, PointDerecha.position, Quaternion.identity);
                    Rigidbody2D rb2d1 = bullet01.GetComponent<Rigidbody2D>();
                    rb2d1.velocity = new Vector2(1, 0).normalized * Speed;
                    Destroy(bullet01, 2.0f);

                    //IZQUIERDA
                    GameObject bullet02 = Instantiate(bulletPrefabIzquierda, PointIzquierda.position, Quaternion.identity);
                    Rigidbody2D rb2d2 = bullet02.GetComponent<Rigidbody2D>();
                    rb2d2.velocity = new Vector2(-1, 0).normalized * Speed;
                    Destroy(bullet02, 2.0f);

                    //ABAJO
                    GameObject bullet03 = Instantiate(bulletPrefabAbajo, PointAbajo.position, Quaternion.identity);
                    Rigidbody2D rb2d3 = bullet03.GetComponent<Rigidbody2D>();
                    rb2d3.velocity = new Vector2(0, -1).normalized * Speed;
                    Destroy(bullet03, 2.0f);

                    //ARRIBA
                    GameObject bullet04 = Instantiate(bulletPrefabArriba, PointArriba.position, Quaternion.identity);
                    Rigidbody2D rb2d4 = bullet04.GetComponent<Rigidbody2D>();
                    rb2d4.velocity = new Vector2(0, 1).normalized * Speed;
                    Destroy(bullet04, 2.0f);
                }
                else
                {


                    //DERECHA
                    GameObject bullet09 = Instantiate(bulletPrefabDerecha, PointDerecha.position, Quaternion.identity);
                    Rigidbody2D rb2d9 = bullet09.GetComponent<Rigidbody2D>();
                    rb2d9.velocity = new Vector2(1, 0).normalized * Speed;
                    Destroy(bullet09, 2.0f);

                    //IZQUIERDA
                    GameObject bullet10 = Instantiate(bulletPrefabIzquierda, PointIzquierda.position, Quaternion.identity);
                    Rigidbody2D rb2d10 = bullet10.GetComponent<Rigidbody2D>();
                    rb2d10.velocity = new Vector2(-1, 0).normalized * Speed;
                    Destroy(bullet10, 2.0f);

                    //ABAJO
                    GameObject bullet11 = Instantiate(bulletPrefabAbajo, PointAbajo.position, Quaternion.identity);
                    Rigidbody2D rb2d11 = bullet11.GetComponent<Rigidbody2D>();
                    rb2d11.velocity = new Vector2(0, -1).normalized * Speed;
                    Destroy(bullet11, 2.0f);

                    //ARRIBA
                    GameObject bullet12 = Instantiate(bulletPrefabArriba, PointArriba.position, Quaternion.identity);
                    Rigidbody2D rb2d12 = bullet12.GetComponent<Rigidbody2D>();
                    rb2d12.velocity = new Vector2(0, 1).normalized * Speed;
                    Destroy(bullet12, 2.0f);

                    ///DIAGONAL
                    ///

                    GameObject bullet05 = Instantiate(bulletPrefabDiaDA, PointDia_De_Ar.position, Quaternion.identity);
                    Rigidbody2D rb2d5 = bullet05.GetComponent<Rigidbody2D>();
                    rb2d5.velocity = new Vector2(1, 1).normalized * Speed;
                    Destroy(bullet05, 2.0f);

                    GameObject bullet06 = Instantiate(bulletPrefabDiaIA, PointDia_Iz_Ar.position, Quaternion.identity);
                    Rigidbody2D rb2d6 = bullet06.GetComponent<Rigidbody2D>();
                    rb2d6.velocity = new Vector2(-1, 1).normalized * Speed;
                    Destroy(bullet06, 2.0f);

                    GameObject bullet07 = Instantiate(bulletPrefabDiaDAB, PointDia_De_Aba.position, Quaternion.identity);
                    Rigidbody2D rb2d7 = bullet07.GetComponent<Rigidbody2D>();
                    rb2d7.velocity = new Vector2(1, -1).normalized * Speed;
                    Destroy(bullet07, 2.0f);

                    GameObject bullet08 = Instantiate(bulletPrefabDiaIAB, PointDia_Iz_Aba.position, Quaternion.identity);
                    Rigidbody2D rb2d8 = bullet08.GetComponent<Rigidbody2D>();
                    rb2d8.velocity = new Vector2(-1, -1).normalized * Speed;
                    Destroy(bullet08, 2.0f);






                }

                if (obj != null)
                {
                    obj.transform.position = transform.position;
                    Destroy(obj, 3.0f);
                }

                yield return new WaitForSeconds(3);

                count++;
            }
        }
    }

}
