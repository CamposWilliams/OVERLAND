
using UnityEngine;


public class JugadorDisparo : MonoBehaviour
{

    float tiempo;
    bool puedeDisparar = true;
    public float cdDisparo = 0.6f;
    public GameObject balaPrefab;
    Animator MikeAnimator;
    bool muere;


    //Municion de armas 
    int AmmoPistola;
    [SerializeField] int AmmoSudmisil = 5;
    [SerializeField] int AmmoRifle = 5;
    [SerializeField] int AmmoEspecial = 5;
    [SerializeField] int CambioArma = 5;

    //cambio de arma 
    //public int MaxCambioArma = 2;


    //Maxima capacidad de municion de cada arma
    int maxAmmoPistola;
    int maxAmmoSudmisil = 25;
    int maxAmmoRifle = 20;
    int maxAmmoEspecial = 25;

    //Almacen de balas

    public int almacenBulletSudmisil = 0;
    public int almacenBulletRifle = 0;
    public int almacenBulletEspecial = 0;

    //maxAlmacen
    int maxAlmacenBulletSudmisil = 25;
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
                MikeAnimator.SetTrigger("PresionaQ");
                CambioArma++;
                CambioArma %= 4;
            }
            //Debug.Log(CambioArma);
        }

    }

    void Recargando() // Como son para 4 armas diferentes, puedes ampliarlo o cambiarlo si quieres (por enmuarator por ejemplo)
    {
        if (puedeDisparar == false)
        {
            /*Debug.Log("Iniciando");*/

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

        if (CambioArma >= 4)
        {
            CambioArma *= 0;
        }

        if (CambioArma == 0)
        {
            ShootPistola();
        }

        else if (CambioArma == 2)
        {
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

            if (Input.GetMouseButtonDown(0) && AmmoRifle > 0)
            {
                ShootRifle();
                AmmoRifle--;
            }
        }


        else if (CambioArma == 1)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {

                // Recargar
                if (AmmoSudmisil < maxAmmoSudmisil)
                {
                    int bulletsToReload = Mathf.Min(almacenBulletSudmisil, maxAmmoSudmisil - AmmoSudmisil);
                    AmmoSudmisil += bulletsToReload;
                    almacenBulletSudmisil -= bulletsToReload;
                }

                // Asegurarnos de que AmmoRifle no exceda el máximo
                AmmoSudmisil = Mathf.Min(AmmoSudmisil, maxAmmoSudmisil);

                // Mantener almacenBulletRifle en positivo
                almacenBulletSudmisil = Mathf.Abs(almacenBulletSudmisil);
            }


            if (Input.GetMouseButtonDown(0) && AmmoSudmisil > 0)
            {
                ShootSudMisil();
                AmmoSudmisil--;
            }


        }


        else if (CambioArma == 3)
        {

            if (Input.GetKeyDown(KeyCode.R))
            {
                // Recargar
                if (AmmoEspecial < maxAmmoEspecial)
                {
                    int bulletsToReload = Mathf.Min(almacenBulletEspecial, maxAmmoEspecial - AmmoEspecial);
                    AmmoEspecial += bulletsToReload;
                    almacenBulletEspecial -= bulletsToReload;
                }

                // Asegurarnos de que AmmoRifle no exceda el máximo
                AmmoEspecial = Mathf.Min(AmmoEspecial, maxAmmoEspecial);

                // Mantener almacenBulletRifle en positivo
                almacenBulletEspecial = Mathf.Abs(almacenBulletEspecial);

            }



            if (Input.GetMouseButtonDown(0) && AmmoEspecial > 0)
            {
                ShootEspecial();
                AmmoEspecial--;
            }

        }  

    }

    /// <summary>
    /// ///////////
    /// </summary>

    void ShootPistola()
    {
        if (Input.GetMouseButtonDown(0) && puedeDisparar == true)
        {
            puedeDisparar = false;


            GetComponent<MikeDisparo>().balaCreada = true;
            GetComponent<MikeDisparo>().DireccionDeLaBala(balaPrefab,0);
         
        }

    }

    void ShootRifle()
    {
        if (Input.GetMouseButtonDown(0))
        {
        
            GetComponent<MikeDisparo>().balaCreada = true;
            GetComponent<MikeDisparo>().DireccionDeLaBala(balaPrefab, 1);

        }
    }

    void ShootSudMisil()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<MikeDisparo>().balaCreada = true;
            GetComponent<MikeDisparo>().DireccionDeLaBala(balaPrefab, 2);         

        }
    }

        void ShootEspecial()
        {
            if (Input.GetMouseButtonDown(0))
            {
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



        //SUBMISIL
        void ChangeAmmoSudMisil(int value)
        {

            AmmoSudmisil += value;

            if (AmmoSudmisil >= maxAmmoSudmisil)
            {
                AmmoSudmisil = maxAmmoSudmisil;
            }
        }

        void StoreAmmoSubMisil(int value)
        {
            almacenBulletSudmisil += value;

            if (almacenBulletSudmisil >= maxAlmacenBulletSudmisil)
            {
                almacenBulletSudmisil = maxAlmacenBulletSudmisil;
            }

        }


        //ESPECIAL
        void ChangeAmmoEspecial(int value)
        {

            AmmoEspecial += value;

            if (AmmoEspecial >= maxAmmoEspecial)
            {
                AmmoEspecial = maxAmmoEspecial;
            }
        }

        void StoreAmmoEspecial(int value)
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
            StoreAmmoEspecial(2);

            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Ammo"))
        {
            StoreAmmoRifle(2);
            StoreAmmoSubMisil(2);
            Destroy(collision.gameObject);
        }

    }



        //////////
        ////////
        /////
        ///



    
}


