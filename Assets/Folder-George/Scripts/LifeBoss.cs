using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBoss : MonoBehaviour
{
    [SerializeField] int vida = 3;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public bool IsAlive()
    {
        return vida > 0;
    }

    void ChangeLife(int value)
    {
        vida += value;

        if (vida <= 0)
        {
            animator.SetTrigger("Dead");
            Destroy(gameObject, 3f);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bala_player"))
        {
            ChangeLife(-1);
            Destroy(collision.gameObject);
        }
    }
}