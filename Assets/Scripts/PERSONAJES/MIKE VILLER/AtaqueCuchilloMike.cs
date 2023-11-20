using UnityEngine;
using System.Collections;

public class AtaqueCuchilloMike : MonoBehaviour
{
    public GameObject[] collidersCuchillo;
    Rigidbody2D MikeRb2D;
    bool leerCorrutina ;
    Animator MikeAnimacion;


    private void Start()
    {
        MikeRb2D = GetComponent<Rigidbody2D>();
        MikeAnimacion = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown("space") && !leerCorrutina)
        {
            MikeAnimacion.SetBool("SePresionaLaBarraEspaciadora", true);
            
            StartCoroutine(ActivacionDeColliders());
        }
        
    }

    IEnumerator ActivacionDeColliders()
    {
        leerCorrutina = true;

        if (MikeRb2D.velocity.x > 0)
        {
            collidersCuchillo[0].SetActive(true);
        }
        else if (MikeRb2D.velocity.x < 0)
        {
            collidersCuchillo[2].SetActive(true);
        }
        else if (MikeRb2D.velocity.y > 0)
        {
            collidersCuchillo[1].SetActive(true);
        }
        else if (MikeRb2D.velocity.y < 0)
        {
            collidersCuchillo[3].SetActive(true);
        }
        
        yield return new WaitForSeconds(1.1f);
        MikeAnimacion.SetBool("SePresionaLaBarraEspaciadora", false);

        foreach (var collider in collidersCuchillo)
        {
            if (collider != null)
            {
                collider.SetActive(false);
            }
        }

        leerCorrutina = false;
    }
}
