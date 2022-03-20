using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameEvent : MonoBehaviour
{

    public static StartGameEvent start;

    public event Action onStartGameTrigger;

    public GameObject tapToPlayCanvas;

    private void Awake()
    {
        start = this;
    }


    public void StartGameTrigger()
    {
        if (onStartGameTrigger != null)
        {
            onStartGameTrigger();
            tapToPlayCanvas.SetActive(false);
            Destroy(this);
        }
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse button pressed.");
            StartGameTrigger();
        }
    }


}
