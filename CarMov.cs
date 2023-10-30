using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMov : MonoBehaviour
{
    public WheelCollider wheelCollider_FrontRight;
    public WheelCollider wheelCollider_FrontLeft;
    public WheelCollider wheelCollider_BackRight;
    public WheelCollider wheelCollider_BackLeft;

    public Transform wheelTransform_FrontRight;
    public Transform wheelTransform_FrontLeft;
    public Transform wheelTransform_BackRight;
    public Transform wheelTransform_BackLeft;


    public float acceleration = 100f;
    private float PresentAcceleration = 0f;
    public float Faraml = 200f;
    private float PresentFarml = 0f;

    public float harkt_ElWheels = 20f;
    private float presentTurnAngle = 0f;


    public movement movScript;
    //lama el player ykon gowa el radius dah hy2dar y3od
    //lw la2 f hayfdal yt7arak 3ady b gesmo 
    private float radius = 5f;
    private bool doorOpen=false;
    public GameObject mainCamera;
    public GameObject CarCamera;
    public GameObject player;
    public Transform carDoor;


    // Update is called once per frame
    void Update()
    {
        //howa el player orayb men el car wala la2?
        if(Vector3.Distance(transform.position,player.transform.position)<radius)
        {
            //aywa el player orayb men el car
            if(Input.GetKeyDown(KeyCode.F))
            {
                doorOpen = true;
                radius = 5000f;

            }
            //el player 3ayz ynzl men el 3arabya 
            else if(Input.GetKeyDown(KeyCode.G))
            {
                player.transform.position = carDoor.transform.position;
                doorOpen = false;
                radius = 5f;
            }
        }
        //howa gowa el car
        if (doorOpen == true)
        {
            //mainCamera.SetActive(false);
            CarCamera.SetActive(true);
            player.SetActive(false);
            moveCar();
            Steering();
            ApplyBreaks();
        }
        else if(doorOpen == false)
        {
            CarCamera.SetActive(false);
           // mainCamera.SetActive(true);
            player.SetActive(true);
        }
       
    }

    void moveCar()
    {
        wheelCollider_FrontRight.motorTorque = PresentAcceleration;
        wheelCollider_FrontLeft.motorTorque = PresentAcceleration;
        wheelCollider_BackRight.motorTorque = PresentAcceleration;
        wheelCollider_BackLeft.motorTorque = PresentAcceleration;

        PresentAcceleration = acceleration * Input.GetAxis("Vertical");



    }
    //twgih el 3arabya ma3a el Left and Right (horizontal)
    void Steering()
    {
        presentTurnAngle = harkt_ElWheels * Input.GetAxis("Horizontal");
        wheelCollider_FrontRight.steerAngle = presentTurnAngle;
        wheelCollider_FrontLeft.steerAngle = presentTurnAngle;


        //animation el wheels
        SteeringWheels(wheelCollider_FrontRight, wheelTransform_FrontRight);
        SteeringWheels(wheelCollider_FrontLeft, wheelTransform_FrontLeft);


        SteeringWheels(wheelCollider_BackRight, wheelTransform_BackRight);
        SteeringWheels(wheelCollider_BackLeft, wheelTransform_BackLeft);

    }

    void SteeringWheels(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 position;
        Quaternion rotation;
        wheelCollider.GetWorldPose(out position, out rotation);
        wheelTransform.position = position;
        wheelTransform.rotation = rotation;

    }

    void ApplyBreaks()
    {
        if (Input.GetKey(KeyCode.Space)) 
        {
            PresentFarml = Faraml;

        }
        else
        {
            PresentFarml = 0f;
        }

        wheelCollider_FrontRight.brakeTorque = PresentFarml;
        wheelCollider_FrontLeft.brakeTorque = PresentFarml;
        wheelCollider_BackLeft.brakeTorque = PresentFarml;
        wheelCollider_BackRight.brakeTorque = PresentFarml;

    }
}