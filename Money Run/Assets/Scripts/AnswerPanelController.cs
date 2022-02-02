using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
public class AnswerPanelController : MonoBehaviour
{
    public int collector=0;


    public StackBodiesController sbc;

    public TextMeshProUGUI collectorText;

    private DOTweenAnimation dta;

    public TriviaManager tm;

    private void Awake()
    {
        dta = collectorText.GetComponent<DOTweenAnimation>();
    }

    private Stack myStack;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="StackTrigger")
        {
            myStack = other.gameObject.GetComponent<Stack>();
            Debug.Log("Collided stack number is " + myStack.myIndex);
            if (myStack.isStacked)
            {
                int cashIndex = myStack.myIndex;
                

                collector++;
                dta.DOComplete();
                Debug.Log("Killed animation");
                collectorText.text = collector.ToString();

                dta.DOPlay();

                sbc.CollectCash(cashIndex);


                if (cashIndex == 0)
                {
                    Debug.Log("Trivia score is " + tm.GetTriviaScore() + ".");
                }

            }
        }
            
        

           
        
    }
}
