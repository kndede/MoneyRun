using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EndGameEvents : MonoBehaviour
{

    public static EndGameEvents ending;

    public event Action onEndGameTrigger;

    public List<StackedCash> collectedCash;

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
        Debug.LogError("Finish");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag==("Player"))
        {

            EndGameTrigger();
        }
        else if (other.tag=="moneystash")
        {
            StackedCash sc = other.gameObject.GetComponent<StackedCash>();
            collectedCash.Add(sc);
        }
    }

    void CollectStacks()
    {

    }
}
