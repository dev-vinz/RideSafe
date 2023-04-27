using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider backRight;
    [SerializeField] WheelCollider backLeft;

    [SerializeField] Transform frontRightTransform;
    [SerializeField] Transform frontLeftTransform;
    [SerializeField] Transform backRightTransform;
    [SerializeField] Transform backLeftTransform;

    [SerializeField] Light rearLeft;
    [SerializeField] Light rearRight;

    [SerializeField] GameObject timer;

    public float acceleration = 500f;
    public float breakingForce = 600f;
    public float maxTurnAngle = 25f;

    private float currentAcceleration = 0f;
    private float currentBreakingForce = 0f;
    private float currentTurnAngle = 0f;

    private new Transform transform;

    private Vector3 initialPosition;
    private Quaternion initialRotation;

    private TimerScript timerScript;
    private bool gameStarted;

    public void LaunchGame(int level)
    {
        gameStarted = true;

        switch (level) 
        {
        case 0:
            transform.position = new Vector3(-45.35f, 1.1f, 78.35f);
            transform.rotation = Quaternion.Euler(0, -90, 0);
            break;
        case 1:
            transform.position = new Vector3(212.4f, 1.22f, 121.6f);
            transform.rotation = Quaternion.Euler(0, 90, 0);
            break;
        case 2:
            transform.position = new Vector3(651.68f, 1.1f, 120.57f);
            transform.rotation = new Quaternion(0f, 0f, 0f, 1f);
            break;
        case 3:
            transform.position = new Vector3(992.70f, 1.10f, 124.71f);
            transform.rotation = new Quaternion(0f, 0f, 0f, 1f);
            break;
        }

        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    private void Start()
    {
        rearLeft.intensity = 0;
        rearRight.intensity = 0;

        transform = GetComponent<Transform>();

        timer.TryGetComponent<TimerScript>(out timerScript);

        gameStarted = false;
    }

    private void FixedUpdate()
    {
        if(gameStarted)
        {
            currentAcceleration = acceleration * Input.GetAxis("Vertical");

            if(Input.GetKey(KeyCode.Space))
            {
                currentAcceleration = 0f;
                currentBreakingForce = breakingForce;
                rearLeft.intensity = 10;
                rearRight.intensity = 10;
            }
            else
            {
                rearLeft.intensity = 0;
                rearRight.intensity = 0;
                currentBreakingForce = 0f;
            }

            if(Input.GetKey(KeyCode.R))
            {
                currentAcceleration = 0f;
                currentBreakingForce = 0f;
                currentTurnAngle = 0f;

                transform.position = initialPosition;
                transform.rotation = initialRotation;

                if (timerScript != null)
                {
                    timerScript.Restart();
                }
            }

            // Forward tracking car
            frontRight.motorTorque = currentAcceleration;
            frontLeft.motorTorque = currentAcceleration;
            backRight.motorTorque = currentAcceleration;
            backLeft.motorTorque = currentAcceleration;

            frontRight.brakeTorque = currentBreakingForce;
            frontLeft.brakeTorque = currentBreakingForce;
            backRight.brakeTorque = currentBreakingForce;
            backLeft.brakeTorque = currentBreakingForce;

            currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");

            frontLeft.steerAngle = currentTurnAngle;
            frontRight.steerAngle = currentTurnAngle;

            UpdateWheel(frontRight, frontRightTransform);
            UpdateWheel(frontLeft, frontLeftTransform);
            UpdateWheel(backRight, backRightTransform);
            UpdateWheel(backLeft, backLeftTransform);
        }
        else
        {

        }
    }

    private void UpdateWheel(WheelCollider col, Transform trans)
    {
        Vector3 position;
        Quaternion rotation;

        col.GetWorldPose(out position, out rotation);

        trans.position = position;
        trans.rotation = rotation;
    }
}
