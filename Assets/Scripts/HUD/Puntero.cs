using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntero : MonoBehaviour
{
     Camera cam;


    // Update is called once per frame
    private void Start()
    {
        cam=Camera.main;
    }
    void Update()
    {


        transform.position = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);



    }
}
