
using UnityEngine;
using TMPro;


public class JugadorDisparo : MonoBehaviour
{
    public TextMeshProUGUI textMeshProSubfusil;
    public TextMeshProUGUI textMeshProRifle;
    public TextMeshProUGUI textMeshProArmaEspecial;

    public TextMesh cantidadBalasTextMesh;
    public AudioSource Disparo3;
    public AudioSource Recarga2;
    public AudioSource CambioDeArma;
    public AudioSource Recarga1;
    public AudioSource DisparoEspecial;
    public AudioSource Disparo1;
    public AudioSource Disparo2;
    float tiempo;
    float tiempo2;
    float contador2;
    float contador1;
    public bool puedeDisparar = true;
    public bool puedeDisparar2 = true;
    public float cdDisparo = 0.6f;
    public float cdRecarga = 2;
    public GameObject balaPrefab;
    float contador;
    Animator MikeAnimator;
    bool muere;
    bool cogiendoMunicion;
    bool estaConRifle;
    public Animator disfazAnimator;
    float valorRandom;


    //Municion de armas 
    int AmmoPistola;
    [SerializeField] int AmmoSubfusil = 5;
    [SerializeField] int AmmoRifle = 5;
    [SerializeField] int AmmoArmaEspecial = 5;
    public int CambioArma = 5;

    //cambio de arma 
    //public int MaxCambioArma = 2;


    //Maxima capacidad de municion de cada arma
    int maxAmmoPistola;
    int maxAmmoSubfusil = 30;
    int maxAmmoRifle = 30;
    int maxAmmoArmaEspecial = 30;

    //Almacen de balas

    public int almacenBulletSubfusil = 0;
    public int almacenBulletRifle = 0;
    public int almacenBulletEspecial = 0;

    //maxAlmacen
    int maxAlmacenBulletSubfusil = 25;
    int maxAlmacenBulletRifle = 25;
    int maxAlmacenBulletEspecial = 25;

    private void Start()
    {
     
        MikeAnimator = GetComponent<Animator>();
        UpdateAmmoUI();
    }
    void Update()
    {

        //Debug.Log(contador1);
        muere = GetComponent<SistemaDeVida>().sinVida;
        if (muere == false)
        {

            Recargando();
            ShootGeneral();
            RecargandoReal();



            if (Input.GetKeyDown(KeyCode.Q))
            {
                CambioDeArma.Play();
                MikeAnimator.SetTrigger("PresionaQ");
                CambioArma++;
                CambioArma %= 4;
            }
            //Debug.Log(CambioArma);

            if (Input.GetKeyDown(KeyCode.R))
            {
                puedeDisparar2 = false;
            }
        }

    }
    void UpdateAmmoUI()
    {

        textMeshProSubfusil.text = AmmoSubfusil.ToString();
        textMeshProRifle.text = AmmoRifle.ToString();
        textMeshProArmaEspecial.text = AmmoArmaEspecial.ToString();
    }

    void Recargando()
    {
        if (puedeDisparar == false && puedeDisparar2)
        {

            tiempo += Time.deltaTime;

            if (tiempo >= cdDisparo)
            {
                puedeDisparar = true;
                tiempo = 0;


            }
        }
    }

    void RecargandoReal()
    {
        if (CambioArma != 3)
        {
            if (puedeDisparar2 == false)
            {
                puedeDisparar = false;
                tiempo2 += Time.deltaTime;

                if (tiempo2 >= 1)
                {
                    contador1 = 0;
                    contador2 = 0;
                    puedeDisparar2 = true;
                    puedeDisparar = true;
                    tiempo2 = 0;
                    UpdateAmmoUI();
                }
            }
        }
        else
        {
            if (puedeDisparar2 == false)
            {
                puedeDisparar = false;
                tiempo2 += Time.deltaTime;

                if (tiempo2 >= cdRecarga)
                {
                    contador1 = 0;
                    contador2 = 0;
                    puedeDisparar2 = true;
                    puedeDisparar = true;
                    tiempo2 = 0;
                    UpdateAmmoUI();

                }
            }
        }
        
    }
    void ShootGeneral()
    {
        switch (CambioArma)
        {
            case 0: ShootPistola(); break;
            case 1: ShootSubfusil(); break;
            case 2: ShootRifle(); break;
            case 3: ShootArmaEspecial(); break;
        }

        if (CambioArma >= 4)
        {
            CambioArma *= 0;
        }

        else if (CambioArma == 0)
        {
            estaConRifle = false;

            if (contador1 == 12 && contador2==0 )
            {
                Recarga1.Play();
                puedeDisparar2 = false;
                contador2++;
            }
            //HolaHola

        }

        else if (CambioArma == 2)
        {
            estaConRifle = false;

            if (Input.GetKeyDown(KeyCode.R))
            {

                Recarga1.Play();
                // Recargar
                if (AmmoRifle < maxAmmoRifle)
                {
                    Debug.Log("Se recargo");
                    int bulletsToReload = Mathf.Min(almacenBulletRifle, maxAmmoRifle - AmmoRifle);
                    AmmoRifle += bulletsToReload;
                    almacenBulletRifle -= bulletsToReload;
                }

                // Asegurarnos de que AmmoRifle no exceda el máximo
                AmmoRifle = Mathf.Min(AmmoRifle, maxAmmoRifle);

                // Mantener almacenBulletRifle en positivo
                almacenBulletRifle = Mathf.Abs(almacenBulletRifle);

            }


            if (!puedeDisparar2 && contador2 == 0)
            {

                Recarga1.Play();
                // Recargar
                if (AmmoRifle < maxAmmoRifle)
                {
                    Debug.Log("Se recargo");
                    int bulletsToReload = Mathf.Min(almacenBulletRifle, maxAmmoRifle - AmmoRifle);
                    AmmoRifle += bulletsToReload;
                    almacenBulletRifle -= bulletsToReload;
                }

                // Asegurarnos de que AmmoRifle no exceda el máximo
                AmmoRifle = Mathf.Min(AmmoRifle, maxAmmoRifle);

                // Mantener almacenBulletRifle en positivo
                almacenBulletRifle = Mathf.Abs(almacenBulletRifle);

                contador2++;
            }

        }


        else if (CambioArma == 1)
        {
            estaConRifle = true;

            if (Input.GetKeyDown(KeyCode.R))
            {
                Recarga1.Play();

                // Recargar
                if (AmmoSubfusil < maxAmmoSubfusil)
                {
                    int bulletsToReload = Mathf.Min(almacenBulletSubfusil, maxAmmoSubfusil - AmmoSubfusil);
                    AmmoSubfusil += bulletsToReload;
                    almacenBulletSubfusil -= bulletsToReload;
                }

                // Asegurarnos de que AmmoRifle no exceda el máximo
                AmmoSubfusil = Mathf.Min(AmmoSubfusil, maxAmmoSubfusil);

                // Mantener almacenBulletRifle en positivo
                almacenBulletSubfusil = Mathf.Abs(almacenBulletSubfusil);

            }

            if (!puedeDisparar2 && contador2 == 0)
            {
                Debug.Log(puedeDisparar2);
                Debug.Log(almacenBulletSubfusil);

                Recarga1.Play();

                // Recargar
                if (AmmoSubfusil < maxAmmoSubfusil)
                {
                    int bulletsToReload = Mathf.Min(almacenBulletSubfusil, maxAmmoSubfusil - AmmoSubfusil);
                    AmmoSubfusil += bulletsToReload;
                    almacenBulletSubfusil -= bulletsToReload;
                }

                // Asegurarnos de que AmmoRifle no exceda el máximo
                AmmoSubfusil = Mathf.Min(AmmoSubfusil, maxAmmoSubfusil);

                // Mantener almacenBulletRifle en positivo
                almacenBulletSubfusil = Mathf.Abs(almacenBulletSubfusil);
                contador2++;
            }

        }

        else if (CambioArma == 3)
        {
            estaConRifle = false;

            if (Input.GetKeyDown(KeyCode.R))
            {
                Recarga2.Play();
                // Recargar
                if (AmmoArmaEspecial < maxAmmoArmaEspecial)
                {
                    int bulletsToReload = Mathf.Min(almacenBulletEspecial, maxAmmoArmaEspecial - AmmoArmaEspecial);
                    AmmoArmaEspecial += bulletsToReload;
                    almacenBulletEspecial -= bulletsToReload;
                }

                // Asegurarnos de que AmmoRifle no exceda el máximo
                AmmoArmaEspecial = Mathf.Min(AmmoArmaEspecial, maxAmmoArmaEspecial);

                // Mantener almacenBulletRifle en positivo
                almacenBulletEspecial = Mathf.Abs(almacenBulletEspecial);


            }

            if (!puedeDisparar2 && contador2 == 0)
            {
                Recarga2.Play();
                // Recargar
                if (AmmoArmaEspecial < maxAmmoArmaEspecial)
                {
                    int bulletsToReload = Mathf.Min(almacenBulletEspecial, maxAmmoArmaEspecial - AmmoArmaEspecial);
                    AmmoArmaEspecial += bulletsToReload;
                    almacenBulletEspecial -= bulletsToReload;
                }

                // Asegurarnos de que AmmoRifle no exceda el máximo
                AmmoArmaEspecial = Mathf.Min(AmmoArmaEspecial, maxAmmoArmaEspecial);

                // Mantener almacenBulletRifle en positivo
                almacenBulletEspecial = Mathf.Abs(almacenBulletEspecial);

                contador2++;

            }

        }

    }

    /// <summary>
    /// ///////////
    /// </summary>

    void ShootPistola()
    {
        if ((Input.GetMouseButton(0) && puedeDisparar == true) && puedeDisparar2)
        {
            contador1++;
            Disparo1.Play();
            puedeDisparar = false;

            if (disfazAnimator.GetFloat("PU") == 2 && disfazAnimator.GetBool("ConPU"))
            {
                cdDisparo = 0.2f;
            }
            else cdDisparo = 0.6f;

            GetComponent<MikeDisparo>().balaCreada = true;
            GetComponent<MikeDisparo>().DireccionDeLaBala(balaPrefab, 0);
            UpdateAmmoUI();
        }

    }

    void ShootRifle()
    {
        if ((Input.GetMouseButton(0) && puedeDisparar == true) && AmmoRifle > 0)
        {

            AmmoRifle--;
            Disparo3.Play();
            puedeDisparar = false;

            if (disfazAnimator.GetFloat("PU") == 2 && disfazAnimator.GetBool("ConPU"))
            {
                cdDisparo = 0.13f;
            }
            else cdDisparo = 0.4f;

            GetComponent<MikeDisparo>().balaCreada = true;
            GetComponent<MikeDisparo>().DireccionDeLaBala(balaPrefab, 1);

            UpdateAmmoUI();

        }

        else if (AmmoRifle <= 0 && almacenBulletRifle != 0)
        {
            contador2 = 0;
            puedeDisparar2 = false;
        }
    }

    void ShootSubfusil()
    {
        if ((Input.GetMouseButton(0) && puedeDisparar == true) && AmmoSubfusil >= 3)
        {

            AmmoSubfusil -= 3;
            Disparo2.Play();
            puedeDisparar = false;
            //Condicion del Power Up (PU)
            if (disfazAnimator.GetFloat("PU") == 2 && disfazAnimator.GetBool("ConPU"))
            {
                cdDisparo = 0.26f;
            }
            else cdDisparo = 0.8f;

            GetComponent<MikeDisparo>().balaCreada = true;
            GetComponent<MikeDisparo>().DireccionDeLaBala(balaPrefab, 2);
            UpdateAmmoUI();

        }

        else if (AmmoSubfusil <= 0 && almacenBulletSubfusil != 0)
        {
            contador2 = 0;
            puedeDisparar2 = false;
        }

    }

    void ShootArmaEspecial()
    {

        if ((Input.GetMouseButton(0) && puedeDisparar == true) && AmmoArmaEspecial >= 3)
        {
            AmmoArmaEspecial -= 3;
            DisparoEspecial.Play();
            puedeDisparar = false;


            if (disfazAnimator.GetFloat("PU") == 2 && disfazAnimator.GetBool("ConPU"))
            {
                cdDisparo = 0.2f;
            }

            else cdDisparo = 0.6f;

            GetComponent<MikeDisparo>().balaCreada = true;
            GetComponent<MikeDisparo>().DireccionDeLaBala(balaPrefab, 3);
            UpdateAmmoUI();
        }

        else if (AmmoArmaEspecial <= 3 && almacenBulletEspecial != 0)
        {
            contador2 = 0;
            puedeDisparar2 = false;
        }



    }


    /// <summary>
    /// //            Changes De Ammo y MaxAlmacen
    /// </summary>

    //RIFLE

    void ChangeAmmoRifle(int value)
    {
        AmmoRifle += value;

        if (AmmoRifle >= maxAmmoRifle)
        {
            AmmoRifle = maxAmmoRifle;
        }

    }

    void StoreAmmoRifle(int value)
    {
        almacenBulletRifle += value;

        if (almacenBulletRifle >= maxAlmacenBulletRifle)
        {
            almacenBulletRifle = maxAlmacenBulletRifle;
        }

    }



    //SUBFUSIL
    void ChangeAmmoSubfusil(int value)
    {

        AmmoSubfusil += value;

        if (AmmoSubfusil >= maxAmmoSubfusil)
        {
            AmmoSubfusil = maxAmmoSubfusil;
        }
    }

    void StoreAmmoSubfusil(int value)
    {
        almacenBulletSubfusil += value;

        if (almacenBulletSubfusil >= maxAlmacenBulletSubfusil)
        {
            almacenBulletSubfusil = maxAlmacenBulletSubfusil;
        }

    }


    //ESPECIAL
    void ChangeAmmoArmaEspecial(int value)
    {

        AmmoArmaEspecial += value;

        if (AmmoArmaEspecial >= maxAmmoArmaEspecial)
        {
            AmmoArmaEspecial = maxAmmoArmaEspecial;
        }
    }

    void StoreAmmoArmaEspecial(int value)
    {
        almacenBulletEspecial += value;

        if (almacenBulletEspecial >= maxAlmacenBulletEspecial)
        {
            almacenBulletEspecial = maxAlmacenBulletEspecial;
        }

    }

    ////////////////

    private void OnTriggerEnter2D(Collider2D collision)

    {

        if (collision.gameObject.CompareTag("AmmoEspecial"))
        {

            int[] valoresPosibles = { 3, 5, 10 };
            valorRandom = valoresPosibles[Random.Range(0, 3)];
            switch (valorRandom)
            {
                case 3: StoreAmmoArmaEspecial(3); break;
                case 5: StoreAmmoArmaEspecial(5); break;
                case 10: StoreAmmoArmaEspecial(10); break;
            }
            

            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Ammo"))
        {
            int[] valoresPosibles = { 3, 5, 10 };
            valorRandom = valoresPosibles[Random.Range(0, 3)];
            switch (valorRandom)
            {
                case 3:
                    StoreAmmoRifle(3);
                    StoreAmmoSubfusil(3); break;
                case 5:
                    StoreAmmoRifle(5);
                    StoreAmmoSubfusil(5); break;
                case 10:
                    StoreAmmoRifle(10);
                    StoreAmmoSubfusil(10); break;
            }
            
            Destroy(collision.gameObject);
        }

    }

}
