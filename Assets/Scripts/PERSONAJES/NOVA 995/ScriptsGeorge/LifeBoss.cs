using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;
using UnityEngine.UI;

public class LifeBoss : MonoBehaviour
{
    public AudioSource MuerteBoss;
    
    private Animator animator;

    public float maxHealth =200f;
    public float currentHealth=200f;
    SpriteRenderer BossRenderer;
    public GameObject pre01;
    public GameObject pre02;
    public GameObject pre03;
    public GameObject pre04;
    GameObject Mike;
    public Image healthBar;
    int contador;
    public GameObject sangreDisparada;
    float time;
    private void Awake()
    {
        Mike = GameObject.Find("Mike");
    }
    void Start()
    { 
        BossRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        UpdateHealthBar();
    }
    private void Update()
    {
        if (currentHealth <= 0)
        {
            time += Time.deltaTime;

            if (time >= 3f)
            {
                SceneManager.LoadScene(6);
            }
        }
       
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

        if (currentHealth <= 0 && contador==0)
        {
           
            contador++;
            MuerteBoss.Play();
            currentHealth = 0;
            animator.SetTrigger("Dead");
            Destroy(gameObject, 3.2f);
        }

        else if(currentHealth == 180)
        {
            GameObject obj = Instantiate(pre01);
            obj.transform.position = transform.position;

            Destroy(obj, 15f);

        }

        else if (currentHealth == 140)
        {
            GameObject obj = Instantiate(pre02);
            obj.transform.position = transform.position;

            Destroy(obj, 15f);

        }
        else if (currentHealth == 80)
        {
            GameObject obj = Instantiate(pre03);
            obj.transform.position = transform.position;
            Destroy(obj, 15f);
        }
        else if (currentHealth == 40)
        {
            GameObject obj = Instantiate(pre04);
            obj.transform.position = transform.position;
            Destroy(obj, 15f);
        }


        UpdateHealthBar();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bala_player") && Mike.GetComponent<JugadorDisparo>().CambioArma==3)
        {
            ChangeLife(-2);
            Destroy(collision.gameObject);
            StartCoroutine(CambiarColor());
        }
        else if (collision.gameObject.CompareTag("Bala_player"))
        {
            ChangeLife(-1);
            StartCoroutine(CambiarColor());
            Destroy(collision.gameObject);
        }
        if (Mike.GetComponent<MikeDisparo>().anguloConstante == 0)
        {
            GameObject nuevaSangre = Instantiate(sangreDisparada);
            nuevaSangre.transform.position = collision.transform.position;
            nuevaSangre.GetComponent<SpriteRenderer>().flipX = true;
            Destroy(nuevaSangre, 0.25f);
        }

        if (Mike.GetComponent<MikeDisparo>().anguloConstante == 90)
        {
            GameObject nuevaSangre = Instantiate(sangreDisparada);
            nuevaSangre.transform.position = collision.transform.position;
            nuevaSangre.transform.Rotate(Vector3.forward * 90);
            Destroy(nuevaSangre, 0.25f);
        }
        if (Mike.GetComponent<MikeDisparo>().anguloConstante == 180)
        {
            GameObject nuevaSangre = Instantiate(sangreDisparada);
            nuevaSangre.transform.position = collision.transform.position;
            nuevaSangre.GetComponent<SpriteRenderer>().flipX = false;
            Destroy(nuevaSangre, 0.25f);
        }
        if (Mike.GetComponent<MikeDisparo>().anguloConstante == 270)
        {
            GameObject nuevaSangre = Instantiate(sangreDisparada);
            nuevaSangre.transform.position = collision.transform.position;
            nuevaSangre.transform.Rotate(Vector3.forward * 270);
            Destroy(nuevaSangre, 0.25f);
        }



    }
    IEnumerator CambiarColor()
    {
        BossRenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        BossRenderer.color = Color.white;
    }
}