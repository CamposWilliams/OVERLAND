using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public int life;
    public int maxLife;

    void ChangeLife(int value)
    {
        life += value;
        if(life > maxLife)
        {
            life = maxLife;
        }
        if(life <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Mutante_01"))
        {
            ChangeLife(-1);
        }
    }


}
