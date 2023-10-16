using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{


    public GameObject bulletPrefab;
    public GameObject gun;
    public GameObject firePoint;
    //public int bullets;
    public Camera cam;

    public Vector2 direction;

    //public BulletText bulletText;

    void Start()
    {
        cam = Camera.main;
        //bulletText = GameObject.Find("BulletTMP").GetComponent<BulletText>();
        //bulletText.SetBullet(bullets);
    }
    void Update()
    {
        Shoot();
        Aim();
    }

    void Aim()
    {
        Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

        direction = mousePosition - gun.transform.position;

        gun.transform.up = direction.normalized;
    }

    void Shoot()
    {
        if (/*bullets > 0 &&*/ Input.GetMouseButtonDown(0))
        {
            GameObject obj = Instantiate(bulletPrefab);
            obj.transform.position = firePoint.transform.position;
            obj.GetComponent<PlayerBullet>().direction = direction.normalized;
            //bullets--;
            //bulletText.SetBullet(bullets);
        }
    }
}
