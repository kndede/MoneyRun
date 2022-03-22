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

    public GameObject correctImage;
    public GameObject falseImage;
    public float imageDelay = 0;


   // public MyMoney myMoney;


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
        MyMoney._money.AddMoney(correctAnswer.collector*10 , correctAnswerMultiplier);
    }

    public void GetEndscore()
    {
        if (correctAnswer.collector>wrongAnswer.collector)
        {
            correctImage.gameObject.SetActive(true);

        }
        else
        {
            falseImage.gameObject.SetActive(true);
        }
        StartCoroutine(ImageCoroutine());
    }

    IEnumerator ImageCoroutine()
    {

        yield return new WaitForSeconds(imageDelay);

        questionText.gameObject.SetActive(false);

        correctAnswer.gameObject.SetActive(false);
        wrongAnswer.gameObject.SetActive(false);
        falseImage.gameObject.SetActive(false);

        correctImage.gameObject.SetActive(false);


    }
}
