using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class JugadorDisparo : MonoBehaviour
{
    public Camera cam;
    float tiempo;
    bool puedeDisparar=true;
    public float cdDisparo=0.6f;
    public float angulo;
    bool colisionaConObjetos;


    private Animator direcciónMirada;
    //punto de disparo y Prefabs osea las balas 
    public GameObject PointShoot;
    public GameObject gun;
    public GameObject BPrePistola;
    public GameObject BPreSudmisil;
    public GameObject BPreRifle;
    public GameObject BPreEspecial;
    public GameObject BPreCuchillo;

    /*Velocidad de Armas
    [SerializeField] float speedPistola = 2;
    [SerializeField] float speedSudmisil = 4;
    [SerializeField] float speedRifle = 6;
    [SerializeField] float speedEspecial = 5;*/

    //Municion de armas 
    [SerializeField] int AmmoPistola;
    [SerializeField] int AmmoSudmisil;
    [SerializeField] int AmmoRifle = 5;
    [SerializeField] int AmmoEspecial = 5;
    [SerializeField] int AmmoCuchillo = 5;
    [SerializeField] int CambioArma = 5;

    //cambio de arma 
    public int MaxCambioArma = 5;


    //Maxima capacidad de municion de cada arma
    public int maxAmmoPistola;
    public int maxAmmoSudmisil = 25;
    public int maxAmmoRifle = 20;
    public int maxAmmoEspecial = 25;
    public int maxAmmoCuchillo = 10;

    //Almacen de balas

    public int almacenBulletSudmisil = 0;
    public int almacenBulletRifle = 0;
    public int almacenBulletEspecial = 0;
    public int almacenCuchillo = 0;

    //maxAlmacen
    public int maxAlmacenBulletSudmisil = 25;
    public int maxAlmacenBulletRifle = 25;
    public int maxAlmacenBulletEspecial = 25;
    public int maxAlmacenCuchillo = 25;



    // direccion de las balas
    public Vector2 Direction;


    void Start()
    {
        cam = Camera.main;
        direcciónMirada = GetComponent<Animator>();
    }

    void Update()
    {
 
        Recargando();
        ShootGeneral();
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            CambioArma++;
            CambioArma %= MaxCambioArma;
        }

    }

   

    void Recargando() // Como son para 4 armas diferentes, puedes ampliarlo o cambiarlo si quieres (por enmuarator por ejemplo)
    {
        if (puedeDisparar==false)
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
     
        if (CambioArma >= MaxCambioArma)
        {
            CambioArma *= 0;
        }

        if (CambioArma == 0)
        {
            ShootPistola();
        }

        else if (CambioArma == 1)
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


        else if (CambioArma == 2)
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

        else if (CambioArma == 4)
        {

            if (Input.GetKeyDown(KeyCode.R))
            {
                // Recargar
                if (AmmoCuchillo < maxAmmoCuchillo)
                {
                    int bulletsToReload = Mathf.Min(almacenCuchillo, maxAmmoCuchillo - AmmoCuchillo);
                    AmmoCuchillo += bulletsToReload;
                    almacenCuchillo -= bulletsToReload;
                }

                // Asegurarnos de que AmmoRifle no exceda el máximo
                AmmoCuchillo = Mathf.Min(AmmoCuchillo, maxAmmoCuchillo);

                // Mantener almacenBulletRifle en positivo
                almacenCuchillo = Mathf.Abs(almacenCuchillo);

            }



            if (Input.GetMouseButtonDown(0) && AmmoCuchillo > 0)
            {
                ShootCuchillo();
                AmmoCuchillo--;
            }

        }

    }

    /// <summary>
    /// ///////////
    /// </summary>

    void ShootPistola()
    {
        if (Input.GetMouseButtonDown(0) && puedeDisparar==true)
        {
            puedeDisparar= false;
            Debug.Log("pistolaActivada");
            GameObject obj = Instantiate(BPrePistola);

            GetComponent<CambiarDireccionArmaBalaYAnimacion>().DireccionDeLaBala(obj);

        }

    }

    void ShootRifle()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject obj = Instantiate(BPreRifle);
            GetComponent<CambiarDireccionArmaBalaYAnimacion>().DireccionDeLaBala(obj);
        }
    }

    void ShootSudMisil()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject obj = Instantiate(BPreSudmisil);
            GetComponent<CambiarDireccionArmaBalaYAnimacion>().DireccionDeLaBala(obj);
        }

    }

    void ShootEspecial()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject obj = Instantiate(BPreEspecial);
            GetComponent<CambiarDireccionArmaBalaYAnimacion>().DireccionDeLaBala(obj);
        }

    }

    void ShootCuchillo()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject obj = Instantiate(BPreCuchillo);
            GetComponent<CambiarDireccionArmaBalaYAnimacion>().DireccionDeLaBala(obj);


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

    //CUCHILLO

    void ChangeAmmoCuchillo(int value)
    {

        AmmoCuchillo += value;

        if (AmmoCuchillo >= maxAmmoCuchillo)
        {
            AmmoCuchillo = maxAmmoCuchillo;
        }
    }

    void StoreAmmoCuchillo(int value)
    {
        almacenCuchillo += value;

        if (almacenCuchillo >= maxAlmacenCuchillo)
        {
            almacenCuchillo = maxAlmacenCuchillo;
        }

    }


    ////////////////

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("AmmoCuchillo"))
        {
            StoreAmmoCuchillo(2);
            // Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("AmmoEspecial"))
        {
            StoreAmmoEspecial(2);
            //Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("AmmoRifle"))
        {
            StoreAmmoRifle(2);
            // Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("AmmoMisil"))
        {
            StoreAmmoSubMisil(2);
            //  Destroy(collision.gameObject);
        }

    }

    



    //////////
    ////////
    /////
    ///



}


