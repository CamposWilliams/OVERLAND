using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Cam : MonoBehaviour
{
    public GameObject target;

    private float target_poseX;
    private float target_poseY;

    private float poseX;
    private float poseY;

    public float derechaMax;
    public float izquierdaMax;

    public float alturaMax;
    public float altumraMin;

    public float speed;
    public bool encendida = true;


    private void Awake()
    {
        poseX = target_poseX + derechaMax;
        poseY = target_poseY + altumraMin;
        transform.position = Vector3.Lerp(transform.position, new Vector3(poseX , poseY, -1),1) ;

    }

    void Move_Cam()
    {
        if(encendida)
        {
            if(target)
            {
                target_poseX = target.transform.position.x;
                target_poseY = target.transform.position.y;

                if(target_poseX > derechaMax && target_poseX < izquierdaMax)
                {
                    poseX = target_poseX;
                }
                if(target_poseY < alturaMax && target_poseY > altumraMin)
                {
                    poseY = target_poseY;
                }

                transform.position = Vector3.Lerp(transform.position, new Vector3(poseX , poseY, -1), speed * Time.deltaTime);

            }


        }


    }

    void Update()
    {
        Move_Cam();
    }
}
