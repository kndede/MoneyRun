using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EndGameEvents : MonoBehaviour
{

    public static EndGameEvents ending;

    public event Action onEndGameTrigger;

    public List<StackedCash> collectedCash;

    public StackBodiesController sbc;
    public MyMoney myMoney;


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
        Debug.Log("Finish");
    }

    private Stack myStack;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag==("Player"))
        {

            EndGameTrigger();
        }

            if (other.gameObject.tag == "StackTrigger")
            {
                myStack = other.gameObject.GetComponent<Stack>();
                Debug.Log("Collided stack number is " + myStack.myIndex);
                if (myStack.isStacked)
                {
                    int cashIndex = myStack.myIndex;


                     myMoney.money++;
                    myMoney.DisplayMoney();

                    sbc.CollectCash(cashIndex);

                }
            }
        
    }

    void CollectStacks()
    {

    }

    
}
