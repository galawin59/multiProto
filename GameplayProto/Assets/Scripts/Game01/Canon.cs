using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    float speedRotate = 0.5f;
    float speedBall = 500f;
    [SerializeField] GameObject ball = null;
    [SerializeField] Transform pos = null;
    float angleZ = 0f;
    float angleX = 0f;
    bool isActive = false;

    void Start()
    {

    }


    void Update()
    {
        angleX = transform.eulerAngles.x;
        if (transform.eulerAngles.z >= 180 || isActive)
        {

            angleZ = transform.eulerAngles.z - 360f;
            isActive = true;
        }
        if (transform.eulerAngles.z <= 0.5f || !isActive)
        {

            angleZ = transform.eulerAngles.z;
            isActive = false;

        }

        if (Input.GetKey(KeyCode.D) && angleZ >= -34f)
        {
            transform.Rotate(new Vector3(0f, 0f, -speedRotate));
        }
        if (Input.GetKey(KeyCode.Q) && angleZ <= 18f)
        {
            transform.Rotate(new Vector3(0f, 0f, speedRotate));
        }
        if (Input.GetKey(KeyCode.Z) && angleX >= 40f)
        {
            transform.Rotate(new Vector3(-speedRotate, 0f, 0f));
        }
        if (Input.GetKey(KeyCode.S) && angleX <= 80f)
        {
            transform.Rotate(new Vector3(speedRotate, 0f, 0f));
        }
        if (Input.GetMouseButtonDown(0))
        {

            GameObject ballInstance = Instantiate(ball, pos.position, pos.rotation) as GameObject;
            Rigidbody ballRb = ballInstance.GetComponent<Rigidbody>();
            ballRb.AddForce(pos.up * speedBall);
            Destroy(ballInstance, 5f);
        }
    }

}

