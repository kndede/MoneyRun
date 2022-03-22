using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderMovement : MonoBehaviour
{

    public float delta = 2.3f;
    public float slidingSpeed = 2.25f;
    private Vector3 startPos;

    public DestackArea myDestackArea;
    public Vector2 upperLeftCorner;
    public Vector2 downRightCorner;

    private void Awake()
    {
       startPos = new Vector3(0f, 1.3f, transform.position.z);
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
    }

    void SliderMotion()
    {

        Vector3 v = startPos;
        v.x += delta * Mathf.Sin(Time.time * slidingSpeed);
        transform.position = v;
    }

    
    
}
