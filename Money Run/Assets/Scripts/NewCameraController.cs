using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCameraController : MonoBehaviour
{

    public Transform target;

    public float smoothSpeed = 2f;
    public Vector3 offset;


    private void Update()
    {
        
    }
    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition,Time.deltaTime* smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target);
    }
}
