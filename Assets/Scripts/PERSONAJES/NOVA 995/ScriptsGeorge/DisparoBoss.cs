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
    public GameObject Explosion;

    public float Speed = 9.7f;

    void Awake()
    {
        StartCoroutine(Shoot());
    }
IEnumerator Shoot()
    {
        while (true && GetComponent<LifeBoss>().currentHealth>0)
        {
           
            GameObject obj = null;
           

                if (GetComponent<LifeBoss>().currentHealth > 180)
                {
                    
                    GameObject bullet01 = Instantiate(bulletPrefabDerecha);
                    bullet01.transform.position=transform.position;
                    Rigidbody2D rb2d1 = bullet01.GetComponent<Rigidbody2D>();
                    rb2d1.velocity = new Vector2(1, 1).normalized * Speed;
                    Destroy(bullet01, 2.0f);

                    
                    GameObject bullet02 = Instantiate(bulletPrefabIzquierda);
                    bullet02.transform.position=transform.position;
                    Rigidbody2D rb2d2 = bullet02.GetComponent<Rigidbody2D>();
                    rb2d2.velocity = new Vector2(-1, 1).normalized * Speed;
                    Destroy(bullet02, 2.0f);

                  
                    GameObject bullet03 = Instantiate(bulletPrefabAbajo);
                    bullet03.transform.position=transform.position;
                    Rigidbody2D rb2d3 = bullet03.GetComponent<Rigidbody2D>();
                    rb2d3.velocity = new Vector2(1, -1).normalized * Speed;
                    Destroy(bullet03, 2.0f);

                  
                    GameObject bullet04 = Instantiate(bulletPrefabArriba);
                    bullet04.transform.position=transform.position;
                    Rigidbody2D rb2d4 = bullet04.GetComponent<Rigidbody2D>();
                    rb2d4.velocity = new Vector2(-1, -1).normalized * Speed;
                    Destroy(bullet04, 2.0f);

                    yield return new WaitForSeconds(2);
                }
                
                else if (GetComponent<LifeBoss>().currentHealth <=180 && GetComponent<LifeBoss>().currentHealth>140)
                {

                GameObject bullet01 = Instantiate(bulletPrefabDerecha);
                bullet01.transform.position = transform.position;
                Rigidbody2D rb2d1 = bullet01.GetComponent<Rigidbody2D>();
                rb2d1.velocity = new Vector2(1, 1).normalized * Speed;
                Destroy(bullet01, 2.0f);


                GameObject bullet02 = Instantiate(bulletPrefabIzquierda);
                bullet02.transform.position = transform.position;
                Rigidbody2D rb2d2 = bullet02.GetComponent<Rigidbody2D>();
                rb2d2.velocity = new Vector2(-1, 1).normalized * Speed;
                Destroy(bullet02, 2.0f);


                GameObject bullet03 = Instantiate(bulletPrefabAbajo);
                bullet03.transform.position = transform.position;
                Rigidbody2D rb2d3 = bullet03.GetComponent<Rigidbody2D>();
                rb2d3.velocity = new Vector2(1, -1).normalized * Speed;
                Destroy(bullet03, 2.0f);


                GameObject bullet04 = Instantiate(bulletPrefabArriba);
                bullet04.transform.position = transform.position;
                Rigidbody2D rb2d4 = bullet04.GetComponent<Rigidbody2D>();
                rb2d4.velocity = new Vector2(-1, -1).normalized * Speed;
                Destroy(bullet04, 2.0f);

                yield return new WaitForSeconds(2);
                
                    bullet01 = Instantiate(bulletPrefabDerecha, PointDerecha.position, Quaternion.identity);
                    rb2d1 = bullet01.GetComponent<Rigidbody2D>();
                    rb2d1.velocity = new Vector2(1, 0).normalized * Speed;
                    Destroy(bullet01, 2.0f);

                   
                     bullet02 = Instantiate(bulletPrefabIzquierda, PointIzquierda.position, Quaternion.identity);
                     rb2d2 = bullet02.GetComponent<Rigidbody2D>();
                     rb2d2.velocity = new Vector2(-1, 0).normalized * Speed;
                     Destroy(bullet02, 2.0f);

                
                     bullet03 = Instantiate(bulletPrefabAbajo, PointAbajo.position, Quaternion.identity);
                     rb2d3 = bullet03.GetComponent<Rigidbody2D>();
                     rb2d3.velocity = new Vector2(0, -1).normalized * Speed;
                     Destroy(bullet03, 2.0f);

                 
                     bullet04 = Instantiate(bulletPrefabArriba, PointArriba.position, Quaternion.identity);
                     rb2d4 = bullet04.GetComponent<Rigidbody2D>();
                     rb2d4.velocity = new Vector2(0, 1).normalized * Speed;
                     Destroy(bullet04, 2.0f);

                    yield return new WaitForSeconds(1);


               
                
                }
                else if (GetComponent<LifeBoss>().currentHealth <= 140 && GetComponent<LifeBoss>().currentHealth>100)
                {
                obj = Instantiate(bulletPrefabFlow);
                obj.GetComponent<BalaSeguimiento>().velocidad = 3;
                Destroy(obj, 4);
                GameObject clonex = Instantiate(Explosion, transform.position, transform.rotation) as GameObject;
                Destroy(clonex, 4.9f);

                GameObject bullet01 = Instantiate(bulletPrefabDerecha);
                bullet01.transform.position = transform.position;
                Rigidbody2D rb2d1 = bullet01.GetComponent<Rigidbody2D>();
                rb2d1.velocity = new Vector2(1, 1).normalized * Speed;
                Destroy(bullet01, 2.0f);


                GameObject bullet02 = Instantiate(bulletPrefabIzquierda);
                bullet02.transform.position = transform.position;
                Rigidbody2D rb2d2 = bullet02.GetComponent<Rigidbody2D>();
                rb2d2.velocity = new Vector2(-1, 1).normalized * Speed;
                Destroy(bullet02, 2.0f);


                GameObject bullet03 = Instantiate(bulletPrefabAbajo);
                bullet03.transform.position = transform.position;
                Rigidbody2D rb2d3 = bullet03.GetComponent<Rigidbody2D>();
                rb2d3.velocity = new Vector2(1, -1).normalized * Speed;
                Destroy(bullet03, 2.0f);


                GameObject bullet04 = Instantiate(bulletPrefabArriba);
                bullet04.transform.position = transform.position;
                Rigidbody2D rb2d4 = bullet04.GetComponent<Rigidbody2D>();
                rb2d4.velocity = new Vector2(-1, -1).normalized * Speed;
                Destroy(bullet04, 2.0f);

                yield return new WaitForSeconds(1);

                bullet01 = Instantiate(bulletPrefabDerecha, PointDerecha.position, Quaternion.identity);
                rb2d1 = bullet01.GetComponent<Rigidbody2D>();
                rb2d1.velocity = new Vector2(1, 0).normalized * Speed;
                Destroy(bullet01, 2.0f);


                bullet02 = Instantiate(bulletPrefabIzquierda, PointIzquierda.position, Quaternion.identity);
                rb2d2 = bullet02.GetComponent<Rigidbody2D>();
                rb2d2.velocity = new Vector2(-1, 0).normalized * Speed;
                Destroy(bullet02, 2.0f);


                bullet03 = Instantiate(bulletPrefabAbajo, PointAbajo.position, Quaternion.identity);
                rb2d3 = bullet03.GetComponent<Rigidbody2D>();
                rb2d3.velocity = new Vector2(0, -1).normalized * Speed;
                Destroy(bullet03, 2.0f);


                bullet04 = Instantiate(bulletPrefabArriba, PointArriba.position, Quaternion.identity);
                rb2d4 = bullet04.GetComponent<Rigidbody2D>();
                rb2d4.velocity = new Vector2(0, 1).normalized * Speed;
                Destroy(bullet04, 2.0f);

                yield return new WaitForSeconds(3);
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

                    yield return new WaitForSeconds(1);
               


            }

            else if(GetComponent<LifeBoss>().currentHealth <= 100 && GetComponent<LifeBoss>().currentHealth>40)
                {
                
                     obj = Instantiate(bulletPrefabFlow);
                     Destroy(obj, 4);
                     GameObject clonex = Instantiate(Explosion, transform.position, transform.rotation) as GameObject;
                    Destroy(clonex, 4.9f);


                GameObject bullet01 = Instantiate(bulletPrefabDerecha);
                bullet01.transform.position = transform.position;
                Rigidbody2D rb2d1 = bullet01.GetComponent<Rigidbody2D>();
                rb2d1.velocity = new Vector2(1, 1).normalized * Speed;
                Destroy(bullet01, 2.0f);


                GameObject bullet02 = Instantiate(bulletPrefabIzquierda);
                bullet02.transform.position = transform.position;
                Rigidbody2D rb2d2 = bullet02.GetComponent<Rigidbody2D>();
                rb2d2.velocity = new Vector2(-1, 1).normalized * Speed;
                Destroy(bullet02, 2.0f);


                GameObject bullet03 = Instantiate(bulletPrefabAbajo);
                bullet03.transform.position = transform.position;
                Rigidbody2D rb2d3 = bullet03.GetComponent<Rigidbody2D>();
                rb2d3.velocity = new Vector2(1, -1).normalized * Speed;
                Destroy(bullet03, 2.0f);


                GameObject bullet04 = Instantiate(bulletPrefabArriba);
                bullet04.transform.position = transform.position;
                Rigidbody2D rb2d4 = bullet04.GetComponent<Rigidbody2D>();
                rb2d4.velocity = new Vector2(-1, -1).normalized * Speed;
                Destroy(bullet04, 2.0f);

                yield return new WaitForSeconds(1);
                bullet01 = Instantiate(bulletPrefabDerecha, PointDerecha.position, Quaternion.identity);
                rb2d1 = bullet01.GetComponent<Rigidbody2D>();
                rb2d1.velocity = new Vector2(1, 0).normalized * Speed;
                Destroy(bullet01, 2.0f);


                bullet02 = Instantiate(bulletPrefabIzquierda, PointIzquierda.position, Quaternion.identity);
                rb2d2 = bullet02.GetComponent<Rigidbody2D>();
                rb2d2.velocity = new Vector2(-1, 0).normalized * Speed;
                Destroy(bullet02, 2.0f);


                bullet03 = Instantiate(bulletPrefabAbajo, PointAbajo.position, Quaternion.identity);
                rb2d3 = bullet03.GetComponent<Rigidbody2D>();
                rb2d3.velocity = new Vector2(0, -1).normalized * Speed;
                Destroy(bullet03, 2.0f);


                bullet04 = Instantiate(bulletPrefabArriba, PointArriba.position, Quaternion.identity);
                rb2d4 = bullet04.GetComponent<Rigidbody2D>();
                rb2d4.velocity = new Vector2(0, 1).normalized * Speed;
                Destroy(bullet04, 2.0f);

                yield return new WaitForSeconds(2);
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

                    yield return new WaitForSeconds(1);
               
            }

            else if(GetComponent<LifeBoss>().currentHealth <= 40 && GetComponent<LifeBoss>().currentHealth>0)
                {
                obj = Instantiate(bulletPrefabFlow);
                Destroy(obj, 4);
                GameObject clonex = Instantiate(Explosion, transform.position, transform.rotation) as GameObject;
                Destroy(clonex, 4.9f);


                GameObject bullet01 = Instantiate(bulletPrefabDerecha);
                bullet01.transform.position = transform.position;
                Rigidbody2D rb2d1 = bullet01.GetComponent<Rigidbody2D>();
                rb2d1.velocity = new Vector2(1, 1).normalized * Speed;
                Destroy(bullet01, 2.0f);


                GameObject bullet02 = Instantiate(bulletPrefabIzquierda);
                bullet02.transform.position = transform.position;
                Rigidbody2D rb2d2 = bullet02.GetComponent<Rigidbody2D>();
                rb2d2.velocity = new Vector2(-1, 1).normalized * Speed;
                Destroy(bullet02, 2.0f);


                GameObject bullet03 = Instantiate(bulletPrefabAbajo);
                bullet03.transform.position = transform.position;
                Rigidbody2D rb2d3 = bullet03.GetComponent<Rigidbody2D>();
                rb2d3.velocity = new Vector2(1, -1).normalized * Speed;
                Destroy(bullet03, 2.0f);


                GameObject bullet04 = Instantiate(bulletPrefabArriba);
                bullet04.transform.position = transform.position;
                Rigidbody2D rb2d4 = bullet04.GetComponent<Rigidbody2D>();
                rb2d4.velocity = new Vector2(-1, -1).normalized * Speed;
                Destroy(bullet04, 2.0f);

                yield return new WaitForSeconds(1);
                obj = Instantiate(bulletPrefabFlow);
                Destroy(obj, 4);
                clonex = Instantiate(Explosion, transform.position, transform.rotation) as GameObject;
                Destroy(clonex, 4.9f);

                bullet01 = Instantiate(bulletPrefabDerecha, PointDerecha.position, Quaternion.identity);
                rb2d1 = bullet01.GetComponent<Rigidbody2D>();
                rb2d1.velocity = new Vector2(1, 0).normalized * Speed;
                Destroy(bullet01, 2.0f);


                bullet02 = Instantiate(bulletPrefabIzquierda, PointIzquierda.position, Quaternion.identity);
                rb2d2 = bullet02.GetComponent<Rigidbody2D>();
                rb2d2.velocity = new Vector2(-1, 0).normalized * Speed;
                Destroy(bullet02, 2.0f);


                bullet03 = Instantiate(bulletPrefabAbajo, PointAbajo.position, Quaternion.identity);
                rb2d3 = bullet03.GetComponent<Rigidbody2D>();
                rb2d3.velocity = new Vector2(0, -1).normalized * Speed;
                Destroy(bullet03, 2.0f);


                bullet04 = Instantiate(bulletPrefabArriba, PointArriba.position, Quaternion.identity);
                rb2d4 = bullet04.GetComponent<Rigidbody2D>();
                rb2d4.velocity = new Vector2(0, 1).normalized * Speed;
                Destroy(bullet04, 2.0f);

                yield return new WaitForSeconds(1);
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

                yield return new WaitForSeconds(1);
            }

        }
    }

}
