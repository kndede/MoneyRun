using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MyMoney : MonoBehaviour
{

    public TextMeshProUGUI cashCounterText;

    private void Awake()
    {
        cashCounterText= GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        TriviaEndEvents.triviaEndEvents.endTrivia += DisplayMoney;
    }
    public int money { get; set; }

    public void DisplayMoney()
    {
        cashCounterText.text = money.ToString();
    }
}
