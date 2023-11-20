using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoBoss : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float timer;
    public float maxTimer;

    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        timer += Time.deltaTime;
        if (timer >= maxTimer)
        {
            GameObject obj = Instantiate(bulletPrefab);
            obj.transform.position = transform.position;
            Destroy(obj, 3.0f);
            timer = 0;
        }

    }
}
