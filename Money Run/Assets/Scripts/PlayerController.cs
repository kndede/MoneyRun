using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public EndGameEvents endGameEvents;


    public float leftLimit = -2f;
    public float rightLimit = 2f;
    public float forwardSpeed = 4f;
    public float force;

    private float swipeSensivity;
    private float maximumSensivity = 100f;

    private Vector3 targetPos;

    private bool lockLeft;
    private bool lockRight;

    private Rigidbody myRigidbody;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
        endGameEvents.onEndGameTrigger += LockedControl;
    }

    private void Start()
    {
        TouchManager.instance.onTouchBegan += TouchBegan;
        TouchManager.instance.onTouchMoved += TouchMoved;
        TouchManager.instance.onTouchEnded += TouchEnded;
    }

    private void Update()
    {
        Movement();
    }

    private void TouchBegan(TouchInput touch)
    {
        targetPos = transform.position;
    }

    private void TouchEnded(TouchInput touch)
    {
        targetPos = transform.position;
        swipeSensivity = 0f;
        
    }

    private void TouchMoved(TouchInput touch)
    {
        swipeSensivity = Mathf.Abs(touch.DeltaScreenPosition.x);

        if (swipeSensivity > maximumSensivity)
        {
            swipeSensivity = maximumSensivity;
        }

        if (touch.DeltaScreenPosition.x > 0)
        {
            targetPos = new Vector3(rightLimit, transform.position.y, transform.position.z);
        }
        else if (touch.DeltaScreenPosition.x < 0)
        {
            targetPos = new Vector3(leftLimit, transform.position.y, transform.position.z);
        }
        else
        {
            targetPos = transform.position;
        }
    }

    private void DestroyUnnecessary()
    {
        TouchManager.instance.onTouchBegan -= TouchBegan;
        TouchManager.instance.onTouchMoved -= TouchMoved;
        TouchManager.instance.onTouchEnded -= TouchEnded;
        Destroy(this);
    }

    private void Movement()
    {
        if (isLocked)
        {
            return;
        }

        if ((transform.position.x - targetPos.x < 0 && !lockRight) || (transform.position.x - targetPos.x > 0 && !lockLeft))
        {
            if (Time.timeScale >= 0.5f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * swipeSensivity / 2f);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.unscaledDeltaTime * swipeSensivity / 2f);
            }
        }

        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1f), Time.deltaTime * forwardSpeed);
    }

    private bool isLocked = false;
    public void LockedControl()
    {
        isLocked = true;
        forwardSpeed = 0;
    }

    
}
