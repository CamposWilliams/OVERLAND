using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaGordock : MonoBehaviour
{
    public float SaludGordock = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bala_player"))
        {
            SaludGordock--;
            Destroy(collision.gameObject);
            if (SaludGordock <= 0) Destroy(gameObject);
        }
    }
}
