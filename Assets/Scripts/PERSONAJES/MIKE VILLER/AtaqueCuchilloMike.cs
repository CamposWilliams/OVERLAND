using UnityEngine;
using System.Collections;

public class AtaqueCuchilloMike : MonoBehaviour
{
    public GameObject[] collidersCuchillo;
    Rigidbody2D MikeRb2D;
    public bool leerCorrutina;
    Animator MikeAnimacion;
    bool continuarCorrutina;
    bool puedeAtacar=true;


    private void Start()
    {
        MikeRb2D = GetComponent<Rigidbody2D>();
        MikeAnimacion = GetComponent<Animator>();
        StartCoroutine(ActivacionDeColliders());

    }

    private void Update()
    {
        if (Input.GetKeyDown("space") && puedeAtacar)
        {
            puedeAtacar = false;
            continuarCorrutina = true;
            GetComponentInChildren<CambioDeSpritesArmas>().sePresionoSpace = true;
            MikeAnimacion.SetBool("SePresionaLaBarraEspaciadora", true);
            StartCoroutine(ActivacionDeColliders());
           

        }

    }

    IEnumerator ActivacionDeColliders()
    {
        while (continuarCorrutina)
        {
            
            //leerCorrutina =true;

            if (MikeAnimacion.GetFloat("Angulo")==0)
            {
                collidersCuchillo[0].SetActive(true);
            }
            else if (MikeAnimacion.GetFloat("Angulo") == 180)
            {
                collidersCuchillo[2].SetActive(true);
            }
            else if (MikeAnimacion.GetFloat("Angulo") == 90)
            {
                collidersCuchillo[1].SetActive(true);
            }
            else if (MikeAnimacion.GetFloat("Angulo") == 270)
            {
                collidersCuchillo[3].SetActive(true);
            }


            yield return new WaitForSeconds(0.5f);

            GetComponentInChildren<CambioDeSpritesArmas>().sePresionoSpace = false;

            MikeAnimacion.SetBool("SePresionaLaBarraEspaciadora", false);

            foreach (var collider in collidersCuchillo)
            {
                if (collider != null)
                {
                    collider.SetActive(false);
                }
            }



            yield return new WaitForSeconds(0.5f);
            puedeAtacar = true;
            continuarCorrutina = false;
        }

        //leerCorrutina = false;
    }


       



    
}
