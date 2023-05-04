using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbulanceScript : MonoBehaviour
{
    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hdisplacement = Input.GetAxis("Horizontal");
        float vdisplacement = Input.GetAxis("Vertical");

        var displacement = new Vector3(hdisplacement, vdisplacement, 0);
        
        displacement *= speed * Time.deltaTime;

        transform.Translate(displacement);
    }
}
