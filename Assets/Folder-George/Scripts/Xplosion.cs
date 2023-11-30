using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xplosion : MonoBehaviour
{

    public GameObject Explosion;

     

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("paredes"))
        {
            GameObject clonex = Instantiate(Explosion, transform.position, transform.rotation) as GameObject;
            Destroy(clonex, 0.9f);
            Destroy(gameObject);

        }

        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject clonex = Instantiate(Explosion, transform.position, transform.rotation) as GameObject;
            Destroy(clonex, 0.9f);
            Destroy(gameObject);

        }
    }

}
