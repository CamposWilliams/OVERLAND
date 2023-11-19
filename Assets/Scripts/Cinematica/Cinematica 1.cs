using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cinematica : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        //Iniciara la animación
        animator.Play("Panel");
    }

    void Update()
    {
        //Si la animacion ah terminado
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animator.IsInTransition(0))
        {
            // Ir a la escena Nivel1
            SceneManager.LoadScene("NIVEL1");
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("NIVEL1");
        }
    }
}