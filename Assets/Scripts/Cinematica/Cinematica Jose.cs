using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CinematicaJose : MonoBehaviour

{
    public Animator animator;

    void Start()
    {
        
        animator.Play("Panel");
    }

    void Update()
    {
        
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animator.IsInTransition(0))
        {
            
            SceneManager.LoadScene("NIVEL1");
        }
        
    }
}
