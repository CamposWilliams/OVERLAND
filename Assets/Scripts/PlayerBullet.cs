using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

    public float speed;
    public Rigidbody2D rb2d;
    public Vector2 direction;
    public float timer;
    public float maxTimer;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Timer();
    }

    void Move()
    {
        rb2d.velocity = direction * speed;
    }

    void Timer()
    {
        timer += Time.deltaTime;
        if (timer >= maxTimer)
        {
            Destroy(gameObject);
        }
    }
}
