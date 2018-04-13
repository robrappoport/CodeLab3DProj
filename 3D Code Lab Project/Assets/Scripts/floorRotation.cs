using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorRotation : MonoBehaviour {

    public KeyCode tiltForward, tiltBack, tiltLeft, tiltRight;
    private float rotationX, rotationY, rotationZ;
    public float amount;

    public float xMin = -50f;
    public float xMax = 50f;
    public float zMin = -50f;
    public float zMax = 50f;

    private void Start()
    {
        rotationX = transform.eulerAngles.x;
        rotationY = transform.eulerAngles.y;
        rotationZ = transform.eulerAngles.z;
    }
    void FixedUpdate () {

        if (Input.GetKey(tiltForward))
        {
            rotationX += amount * Time.deltaTime;
        }
        if (Input.GetKey(tiltBack))
        {
            rotationX -= amount * Time.deltaTime;
        }
        if (Input.GetKey(tiltLeft))
        {
            rotationZ += amount * Time.deltaTime;
        }
        if (Input.GetKey(tiltRight))
        {
            rotationZ -= amount * Time.deltaTime;
        }

        rotationX = ClampAngle(rotationX, xMin, xMax);
        rotationZ = ClampAngle(rotationZ, zMin, zMax);

        Quaternion newRot = Quaternion.Euler(rotationX, rotationY, rotationZ);
        transform.rotation = newRot;
    }

    float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
        {
            angle += 360;
        }
        if (angle > 360)
        {
            angle -= 360;
        }

        return Mathf.Clamp(angle, min, max);
    }
}
