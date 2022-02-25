using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public float delta = 2.3f;
    [Range(3, 6)]
    public float slidingSpeed = 2f;

    public float speedRot = 25f;


    private Vector3 startPos;

    public DestackArea myDestackArea;
    public Vector2 upperLeftCorner;
    public Vector2 downRightCorner;

    private void Awake()
    {
        startPos = new Vector3(0f, 1f, transform.position.z);
    }


    void Start()
    {
        transform.position = startPos;
        upperLeftCorner = myDestackArea.upperLeft;
        downRightCorner = myDestackArea.downRight;
    }

    void Update()
    {
        SliderMotion();
        Rotation();
    }

    void SliderMotion()
    {

        Vector3 v = startPos;
        v.x += delta * Mathf.Sin(Time.time * slidingSpeed);
        transform.position = v;
    }


    void Rotation()
    {
        float rot = Time.deltaTime * speedRot;
        transform.Rotate(new Vector3(0f, rot, 0f));
          
    }


	
}
