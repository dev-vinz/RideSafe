using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driving : MonoBehaviour
{
    private float baseSpeed;
    private float baseRotation;

    void Start()
    {
        baseSpeed = 10f;
        baseRotation = 0.5f;
    }

    void Update()
    {
        // V2 : Driving with the axis and the keys and a simulation of acceleration
        float speed = Input.GetAxis("Vertical");
        float direction = Input.GetAxis("Horizontal");

        if (speed != 0)
        {
            transform.Translate(Vector3.forward * baseSpeed * speed * Time.deltaTime);

            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(new Vector3(0, direction * baseRotation, 0));
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(new Vector3(0, direction * baseRotation, 0));
            }
        }
        

        // V1 : driving just with the keys
        /*
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector3.forward * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 0.25f, 0));
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, -0.25f, 0));
        }
        */
    }
}
