using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDeSeguimientoVomet : MonoBehaviour
{
    public AIPath aiPath;
    public GameObject Bonk;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            aiPath.enabled = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Bonk.GetComponent<PatrullarVomet>().distance < 0.1f)
        {
            aiPath.enabled = false;

        }

    }
}
