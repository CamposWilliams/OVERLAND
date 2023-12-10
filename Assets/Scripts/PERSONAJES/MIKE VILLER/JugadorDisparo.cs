
using UnityEngine;


public class JugadorDisparo : MonoBehaviour
{
    
    public AudioSource CambioDeArma;
    public AudioSource Recarga1;
    public AudioSource DisparoEspecial;
    public AudioSource Disparo1;
    public AudioSource Disparo2;
    float tiempo;
    public bool puedeDisparar = true;
    public float cdDisparo = 0.6f;
    public GameObject balaPrefab;
    Animator MikeAnimator;
    bool muere;
    bool estaConRifle;
    public Animator disfazAnimator;


    //Municion de armas 
    int AmmoPistola;
    [SerializeField] int AmmoSubfusil = 5;
    [SerializeField] int AmmoRifle = 5;
    [SerializeField] int AmmoArmaEspecial = 5;
    [SerializeField] int CambioArma = 5;

    //cambio de arma 
    //public int MaxCambioArma = 2;


    //Maxima capacidad de municion de cada arma
    int maxAmmoPistola;
    int maxAmmoSubfusil = 25;
    int maxAmmoRifle = 20;
    int maxAmmoArmaEspecial = 25;

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
        MikeAnimator=GetComponent<Animator>();  
    }
    void Update()
    {
        muere = GetComponent<SistemaDeVida>().sinVida;
        if (muere==false)
        {

            Recargando();
            ShootGeneral();

           
            if (Input.GetKeyDown(KeyCode.Q))
            {
                CambioDeArma.Play();
                MikeAnimator.SetTrigger("PresionaQ");
                CambioArma++;
                CambioArma %= 4;
            }
            //Debug.Log(CambioArma);
        }

    }

    void Recargando() 
    {
        if (puedeDisparar == false)
        {

            tiempo += Time.deltaTime;

            if (tiempo >= cdDisparo)
            {
                puedeDisparar = true;
                tiempo = 0;
            }
        }
    }

    void ShootGeneral()
    {
        switch (CambioArma)
        {
            case 0:ShootPistola();break;
            case 1: ShootSubfusil(); break;
            case 2: ShootRifle(); break;
            case 3: ShootArmaEspecial(); break;
        }
      
        if (CambioArma >= 4)
        {
            CambioArma *= 0;
        }

        

        else if (CambioArma == 2)
        {
            estaConRifle = false;

            if (Input.GetKeyDown(KeyCode.R))
            {
                
                // Recargar
                if (AmmoRifle < maxAmmoRifle)
                {
                    int bulletsToReload = Mathf.Min(almacenBulletRifle, maxAmmoRifle - AmmoRifle);
                    AmmoRifle += bulletsToReload;
                    almacenBulletRifle -= bulletsToReload;
                }

                // Asegurarnos de que AmmoRifle no exceda el máximo
                AmmoRifle = Mathf.Min(AmmoRifle, maxAmmoRifle);

                // Mantener almacenBulletRifle en positivo
                almacenBulletRifle = Mathf.Abs(almacenBulletRifle);
            }

            if (Input.GetMouseButton(0) && AmmoRifle > 0)
            {
          
                AmmoRifle--;
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


            if (Input.GetMouseButton(0) && AmmoSubfusil > 0)
            {
                
                AmmoSubfusil--;
            }

        }

        else if (CambioArma == 3)
        {
            estaConRifle = false;

            if (Input.GetKeyDown(KeyCode.R))
            {
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



            if (Input.GetMouseButton(0) && AmmoArmaEspecial > 0)
            {
               
                AmmoArmaEspecial--;
            }

        }  

    }

    /// <summary>
    /// ///////////
    /// </summary>

    void ShootPistola()
    {
        if (Input.GetMouseButton(0) && puedeDisparar == true)
        {
            Disparo1.Play();
            puedeDisparar = false;

            if (disfazAnimator.GetFloat("PU") == 2 && disfazAnimator.GetBool("ConPU"))
            {
                cdDisparo = 0.2f;
            }
            else  cdDisparo = 0.6f;

            GetComponent<MikeDisparo>().balaCreada = true;
            GetComponent<MikeDisparo>().DireccionDeLaBala(balaPrefab, 0);

        }

    }

    void ShootRifle()
    {
        if (Input.GetMouseButton(0) && puedeDisparar == true)
        {
            puedeDisparar = false;


            if (disfazAnimator.GetFloat("PU") == 2 && disfazAnimator.GetBool("ConPU"))
            {
                 cdDisparo = 0.13f;
            }
            else cdDisparo = 0.4f;

            GetComponent<MikeDisparo>().balaCreada = true;
            GetComponent<MikeDisparo>().DireccionDeLaBala(balaPrefab, 1);

        }
    }

    void ShootSubfusil()
    {
        if (Input.GetMouseButton(0) && puedeDisparar == true)
        {
            Disparo2.Play();
            puedeDisparar = false;

            if (disfazAnimator.GetFloat("PU") == 2 && disfazAnimator.GetBool("ConPU"))
            {
                cdDisparo = 0.26f;
            }
            else cdDisparo = 0.8f;

            GetComponent<MikeDisparo>().balaCreada = true;
            GetComponent<MikeDisparo>().DireccionDeLaBala(balaPrefab, 2);         

        }
    }

        void ShootArmaEspecial()
        {
            if (Input.GetMouseButton(0) && puedeDisparar == true)
            {
            DisparoEspecial.Play();
            puedeDisparar = false;

            if (disfazAnimator.GetFloat("PU") == 2 && disfazAnimator.GetBool("ConPU"))
            {
                cdDisparo = 0.2f;
            }
            else cdDisparo = 0.6f;

            GetComponent<MikeDisparo>().balaCreada = true;
            GetComponent<MikeDisparo>().DireccionDeLaBala(balaPrefab, 3);

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

        if (collision.gameObject.CompareTag("Ammo"))
        {
            StoreAmmoArmaEspecial(3);

            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Ammo"))
        {
            StoreAmmoRifle(2);
            StoreAmmoSubfusil(2);
            Destroy(collision.gameObject);
        }

    }



        //////////
        ////////
        /////
        ///



    
}


