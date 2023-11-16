using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaBonk : MonoBehaviour
{
  public  float saludBonk=5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bala_player"))
        {
            saludBonk--;
            Destroy(collision.gameObject);
            if (saludBonk <= 0) Destroy(gameObject);
        }
    }

}
