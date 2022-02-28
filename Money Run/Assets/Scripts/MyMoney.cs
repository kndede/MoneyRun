using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class MyMoney : MonoBehaviour
{

    public TextMeshProUGUI cashCounterText;
    private DOTweenAnimation dta;
    private void Awake()
    {
        cashCounterText= GetComponent<TextMeshProUGUI>();
        dta = GetComponent<DOTweenAnimation>();
    }
    private void Start()
    {
        TriviaEndEvents.triviaEndEvents.endTrivia += DisplayMoney;
    }
    public int money { get; set; }

    public void DisplayMoney()
    {
        dta.DOComplete();
        cashCounterText.text = money.ToString();
        dta.DORestart();
    }
}
