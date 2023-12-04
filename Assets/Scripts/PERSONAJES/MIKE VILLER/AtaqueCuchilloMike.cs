using UnityEngine;
using System.Collections;

public class AtaqueCuchilloMike : MonoBehaviour
{
    public GameObject[] collidersCuchillo;
    public bool leerCorrutina;
    Animator MikeAnimacion;
    bool continuarCorrutina;
    bool puedeAtacar=true;
    public GameObject Mike;


    private void Start()
    {
      
        MikeAnimacion = GetComponent<Animator>();
        StartCoroutine(ActivacionDeColliders());

    }

    private void Update()
    {
        if (Input.GetKeyDown("space") && puedeAtacar)
        {
            puedeAtacar = false;
            continuarCorrutina = true;
            //GetComponentInChildren<CambioDeSpritesArmas>().sePresionoSpace = true;
            MikeAnimacion.SetBool("SePresionaLaBarraEspaciadora", true);
            StartCoroutine(ActivacionDeColliders());
           

        }

    }

    IEnumerator ActivacionDeColliders()
    {
        while (continuarCorrutina)
        {
            
            //leerCorrutina =true;

            if (Mike.GetComponent<MikeDisparo>().anguloConstante==0)
            {
                collidersCuchillo[0].SetActive(true);
            }
            else if (Mike.GetComponent<MikeDisparo>().anguloConstante == 180)
            {
                collidersCuchillo[2].SetActive(true);
            }
            else if (Mike.GetComponent<MikeDisparo>().anguloConstante == 90)
            {
                collidersCuchillo[1].SetActive(true);
            }
            else if (Mike.GetComponent<MikeDisparo>().anguloConstante == 270)
            {
                collidersCuchillo[3].SetActive(true);
            }


            yield return new WaitForSeconds(0.2f);

            //GetComponentInChildren<CambioDeSpritesArmas>().sePresionoSpace = false;

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
