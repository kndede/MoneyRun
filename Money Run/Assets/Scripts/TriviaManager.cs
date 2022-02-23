using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TriviaManager : MonoBehaviour
{
    public TriviaTrigger triviaTrigger;
    public AnswerPanelController correctAnswer;
    public AnswerPanelController wrongAnswer;
    public TextMeshProUGUI questionText;

    public MyMoney myMoney;


    public int correctAnswerMultiplier = 2;
    private void Start()
    {
        TriviaEndEvents.triviaEndEvents.endTrivia += GetEndscore;
    }


    // scriptable obje dizaynı public QuestionScriptableObject questionScriptableObject;


    public void EnablePanels()
    {
       // questionText.text = questionScriptableObject.question;
        questionText.gameObject.SetActive(true);
        correctAnswer.gameObject.SetActive(true);
        wrongAnswer.gameObject.SetActive(true);
    }

    public void ConvertCollected()
    {
        myMoney.money = correctAnswer.collector * correctAnswerMultiplier;
    }

    public void GetEndscore()
    {
        questionText.gameObject.SetActive(false);
    }
}
