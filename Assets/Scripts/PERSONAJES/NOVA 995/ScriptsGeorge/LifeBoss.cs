using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBoss : MonoBehaviour
{
    public AudioSource MuerteBoss;
    
    private Animator animator;

    public float maxHealth = 5f;
    private float currentHealth;

    public GameObject pre01;
    public GameObject pre02;
    public GameObject pre03;
    public GameObject pre04;    

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
            MuerteBoss.Play();
            currentHealth = 0;
            animator.SetTrigger("Dead");
            Destroy(gameObject, 3f);
        }

        else if(currentHealth == 80)
        {
            GameObject obj = Instantiate(pre01);
            obj.transform.position = transform.position;

            Destroy(obj, 10f);

        }

        else if (currentHealth == 60)
        {
            GameObject obj = Instantiate(pre02);
            obj.transform.position = transform.position;

            Destroy(obj, 10f);

        }
        else if (currentHealth == 40)
        {
            GameObject obj = Instantiate(pre03);
            obj.transform.position = transform.position;
            Destroy(obj, 10f);
        }
        else if (currentHealth == 20)
        {
            GameObject obj = Instantiate(pre04);
            obj.transform.position = transform.position;
            Destroy(obj, 10f);
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