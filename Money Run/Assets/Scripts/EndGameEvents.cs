using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class EndGameEvents : MonoBehaviour
{
    public static EndGameEvents ending;

    public event Action onEndGameTrigger;

    public StackBodiesController sbc;

    public GameObject successCanvas;


    public SlotGame slotGame;
    public MyMoney myMoney;
    public TextMeshProUGUI moneyText;


    public LevelManager lvlMngr;
    public TextMeshProUGUI uiMoney;
    public GameObject UIMoney;
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

    public float endGameAnimationDelay = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag==("Player"))
        {

            EndGameTrigger();
            StartCoroutine(SlotEnding());
        }

            if (other.gameObject.tag == "StackTrigger")
            {
                myStack = other.gameObject.GetComponent<Stack>();
                Debug.Log("Collided stack number is " + myStack.myIndex);
                if (myStack.isStacked)
                {
                    int cashIndex = myStack.myIndex;


                     MyMoney._money.AddMoney();
                    MyMoney._money.DisplayMoney();

                    sbc.CollectCash(cashIndex);

                }
            }
        
    }

    IEnumerator SlotEnding()
    {

        yield return new WaitForSeconds(endGameAnimationDelay);

        int winnings = slotGame.SlotWinCondition();

        if (winnings> 2)
        {
            Debug.Log("" + winnings + " katını kazandın!");
            myMoney.money *= winnings;
        }
        else
        {
            Debug.Log("2 katını kazandın!");
            myMoney.money *= winnings;
        }

        myMoney.DisplayMoney();

        yield return new WaitForSeconds(1f);
        LevelManagerWallet();
        uiMoney.text = "$" + lvlMngr.wallet;
        UIMoney.SetActive(true);
        successCanvas.SetActive(true);
    }

    void EndGamePoints()
    {

        myMoney.DisplayMoney();
    }
    void LevelManagerWallet()
    {

        lvlMngr.wallet += myMoney.money;
    }
    
}
