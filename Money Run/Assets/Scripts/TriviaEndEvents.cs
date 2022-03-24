using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TriviaEndEvents : MonoBehaviour
{
    public static TriviaEndEvents triviaEndEvents;

    public event Action<int> endTrivia;
    public List<GameObject> endTriggerObjects;

    public int _triviaCount;
    private void Awake()
    {
        triviaEndEvents = this;
        foreach (GameObject item in endTriggerObjects)
        {
            _triviaCount++;
        }

    }

    public int triviaOrder = 0;
    public void EndTriviaManager(int triviaId)
    {
        if (endTrivia != null)
        {
            endTrivia(triviaOrder);

            triviaOrder++;
        }
    }


    
   

}
