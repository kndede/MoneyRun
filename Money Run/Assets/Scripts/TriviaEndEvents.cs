using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TriviaEndEvents : MonoBehaviour
{
    public static TriviaEndEvents triviaEndEvents;

    public event Action endTrivia;

    private void Awake()
    {
        triviaEndEvents = this;
    }

    public void EndTriviaManager()
    {
        if (endTrivia != null)
        {
            endTrivia();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("StackTrigger"))
        {
            EndTriviaManager();
        }
        
    }

   

}
