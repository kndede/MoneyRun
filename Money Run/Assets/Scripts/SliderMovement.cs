using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderMovement : MonoBehaviour
{

    public float delta = 2.3f;  
    [Range(3, 6)]
    public float slidingSpeed = 3f;
    private Vector3 startPos;

    private void Awake()
    {
       startPos = new Vector3(0f, 2.35f, transform.position.z);
       
    }
   

    void Start()
    {
        transform.position = startPos;
         
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