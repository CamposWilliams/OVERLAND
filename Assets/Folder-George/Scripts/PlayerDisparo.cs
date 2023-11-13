using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDisparo : MonoBehaviour
{
    //punto de disparo y Prefabs osea las balas 
    public GameObject PointShoot;
    public GameObject gun;
    public GameObject BPrePistola;
    public GameObject BPreSudmisil;
    public GameObject BPreRifle;
    public GameObject BPreEspecial;
    public GameObject BPreCuchillo;

    //Velocidad de Armas
    [SerializeField] float speedPistola = 2;
    [SerializeField] float speedSudmisil = 4;
    [SerializeField] float speedRifle = 6;
    [SerializeField] float speedEspecial = 5;

    //Municion de armas 
    [SerializeField] int AmmoPistola;
    [SerializeField] int AmmoSudmisil;
    [SerializeField] int AmmoRifle =  5;
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

    //cam
    public Camera cam;

    void Start()
    {
        cam = Camera.main;
    }


    void Update()
    {
        ShootGeneral();


        if (Input.GetKeyDown(KeyCode.Q))
        {
            CambioArma++;
            CambioArma %= MaxCambioArma;
        }


    }

    /*  void Aim()
      {
          Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

          Direction = mousePosition - gun.transform.position;

          gun.transform.up = Direction.normalized;
      }*/

    void ShootGeneral()
    {

        if (CambioArma >= MaxCambioArma)
        {
            CambioArma *= 0;
        }

        /////////////////////
        if (CambioArma == 0)
        {
            Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

            Direction = mousePosition - gun.transform.position;

            gun.transform.up = Direction.normalized;

            ShootPistola();
        }

        else if (CambioArma == 1 )
        {
            Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

            Direction = mousePosition - gun.transform.position;

            gun.transform.up = Direction.normalized;

            
           if(Input.GetMouseButtonDown(0) && AmmoRifle > 0)
            {
                ShootRifle();
                AmmoRifle--;
            }
            
           

            






        }

        else if (CambioArma == 2)
        {
            Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

            Direction = mousePosition - gun.transform.position;

            gun.transform.up = Direction.normalized;


            if (Input.GetMouseButtonDown(0) && AmmoSudmisil > 0)
            {
                ShootSudMisil();
                AmmoSudmisil--;
            }

            
        }


        else if (CambioArma == 3)
        {

            Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

            Direction = mousePosition - gun.transform.position;

            gun.transform.up = Direction.normalized;


            if (Input.GetMouseButtonDown(0) && AmmoEspecial > 0)
            {
                ShootEspecial();
                AmmoEspecial--;
            }
            
        }

        else if (CambioArma == 4)
        {

            Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

            Direction = mousePosition - gun.transform.position;

            gun.transform.up = Direction.normalized;


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
        if (Input.GetMouseButtonDown(0))
        {
            GameObject obj = Instantiate(BPrePistola);
            obj.transform.position = PointShoot.transform.position;
            obj.GetComponent<BalaPlayer>().direction = Direction.normalized;

        }

    }

    void ShootRifle()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject obj = Instantiate(BPreRifle);
            obj.transform.position = PointShoot.transform.position;
            obj.GetComponent<BalaPlayer>().direction = Direction.normalized;


        }

    }

    void ShootSudMisil()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject obj = Instantiate(BPreSudmisil);
            obj.transform.position = PointShoot.transform.position;
            obj.GetComponent<BalaPlayer>().direction = Direction.normalized;

        }

    }

    void ShootEspecial()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject obj = Instantiate(BPreEspecial);
            obj.transform.position = PointShoot.transform.position;
            obj.GetComponent<BalaPlayer>().direction = Direction.normalized;

        }

    }

    void ShootCuchillo()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject obj = Instantiate(BPreCuchillo);
            obj.transform.position = PointShoot.transform.position;
            obj.GetComponent<BalaPlayer>().direction = Direction.normalized;

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





    //////////
    ////////
    /////
    ///



}

