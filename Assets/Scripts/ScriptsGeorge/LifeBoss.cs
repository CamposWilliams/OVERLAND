using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBoss : MonoBehaviour
{
    [SerializeField] int vida = 5;
    private Animator animator;

    public float maxHealth = 5f;
    private float currentHealth;

    public Image healthBar;

    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        float fillAmount = currentHealth / maxHealth;
        healthBar.fillAmount = fillAmount;
    }

    public bool IsAlive()
    {
        return currentHealth > 0;
    }

    void ChangeLife(int value)
    {
        currentHealth += value;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            animator.SetTrigger("Dead");
            Destroy(gameObject, 3f);
        }

        UpdateHealthBar();
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