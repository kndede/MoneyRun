using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriviaEndTrigger : MonoBehaviour
{
    public int _triviaId;
    private void Start()
    {
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("StackTrigger"))
        {
            TriviaEndEvents.triviaEndEvents.EndTriviaManager(_triviaId);
        }

    }
}
