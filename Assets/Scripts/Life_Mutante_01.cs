using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life_Mutante_01 : MonoBehaviour
{
    public int life;

    void ChangeLife(int value)
    {
        life += value;
        if(life <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bala_player"))
        {
            ChangeLife(-1);
            Destroy(collision.gameObject);
        }
    }


}
