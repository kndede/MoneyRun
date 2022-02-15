using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EndGameEvents : MonoBehaviour
{

    public static EndGameEvents ending;

    public event Action onEndGameTrigger;
    // Start is called before the first frame update
    private void Awake()
    {
        ending = this;
        onEndGameTrigger += EndGame;
    }


    public void EndGameTrigger()
    {
        if (onEndGameTrigger!=null)
        {
            onEndGameTrigger();
        }
    }

    void EndGame()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        EndGameTrigger();
    }
}
