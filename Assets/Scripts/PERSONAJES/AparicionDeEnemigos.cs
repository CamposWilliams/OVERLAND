using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AparicionDeEnemigos : MonoBehaviour
{
    public GameObject[] childObjects; // Numero de enemigos para aparecer

    void Start()
    {
        foreach (GameObject childObject in childObjects)
        {
            if (childObject != null)
            {
                childObject.SetActive(false);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            foreach (GameObject childObject in childObjects)
            {
                if (childObject != null)
                {
                    childObject.SetActive(true);
                }
            }
        }
    }

}
