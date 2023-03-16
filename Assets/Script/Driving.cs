using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driving : MonoBehaviour
{
    private float speed;

    void Start()
    {
        speed = 5f;
    }

    void Update()
    {
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
    }
}
