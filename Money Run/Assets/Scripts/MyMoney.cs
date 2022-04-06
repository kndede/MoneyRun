using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class MyMoney : MonoBehaviour
{
    public static MyMoney _money;
    public TextMeshProUGUI cashCounterText;
    [SerializeField] private DOTweenAnimation dta;
    private void Awake()
    {
        if (_money==null)
        {

            _money = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }

        cashCounterText = GetComponent<TextMeshProUGUI>();
        dta = GetComponent<DOTweenAnimation>();
    }
    private void Start()
    {
        _triviaId = 0;
        DisplayMoney();
        TriviaEndEvents.triviaEndEvents.endTrivia += DisplayMoney;
    }
    public int money;
    public int _triviaId;
    public void DisplayMoney(int triviaId)
    {
        if (triviaId==this._triviaId)
        {
            dta.DOComplete();
            cashCounterText.text = "$" + (money).ToString();
            _triviaId++;
            dta.DORestart();
        }
    }
    public void DisplayMoney()
    {
        dta.DOComplete();
        cashCounterText.text = "$" + (money).ToString();
        dta.DORestart();
    }
    public void AddMoney()
    {
        money += 10;
    }

    public void AddMoney(int amount)
    {

        money += amount;
    }
    public void AddMoney(int amount,int multiplier)
    {

        money += amount*multiplier;
    }


}
