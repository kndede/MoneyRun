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

    public void EnablePanels()
    {
        questionText.gameObject.SetActive(true);
        correctAnswer.gameObject.SetActive(true);
        wrongAnswer.gameObject.SetActive(true);
    }

    public int GetTriviaScore()
    {
        int scoreAfterTrivia = correctAnswer.collector * 2;
        return scoreAfterTrivia;
    }
}
