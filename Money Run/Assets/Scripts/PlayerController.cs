using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    public EndGameEvents endGameEvents;
    public StartGameEvent startGameEvent;
    public Animator characterAnimator;
    


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
    }

    private void Start()
    {
        TouchManager.instance.onTouchBegan += TouchBegan;
        TouchManager.instance.onTouchMoved += TouchMoved;
        TouchManager.instance.onTouchEnded += TouchEnded;

        endGameEvents.onEndGameTrigger += LockedControl;
        endGameEvents.onEndGameTrigger += EndGamePositioning;
        startGameEvent.onStartGameTrigger += LockedControl;
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

    public bool isLocked = true;
    public void LockedControl()
    {
        if (isLocked)
        {
            isLocked = false;
            characterAnimator.SetTrigger("Walk");
            forwardSpeed = 6f;
        }
        else
        {
            isLocked = true;
            characterAnimator.SetTrigger("Idle");
            forwardSpeed = 0;
        }
    }
    private void EndGamePositioning()
    {
        transform.DOLocalMoveX(0, 1.5f);
    }

}
