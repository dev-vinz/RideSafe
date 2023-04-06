using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarFollowing : MonoBehaviour
{
    [SerializeField]
    public Transform car;

    // Update is called once per frame
    void Update()
    {
        transform.position = car.transform.position + new Vector3(0, 5, -10);
    }
}
