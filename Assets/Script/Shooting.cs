using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Rigidbody rigidBody;
    private int force;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        force = 500;
    }

    void Update()
    {
        // Nothing
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the car
        if (collision.gameObject.name == "Sedan")
        {
            rigidBody.AddForce(new Vector3(0, rigidBody.mass * force, 0));
        }
    }
}
