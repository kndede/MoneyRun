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
    public int _triviaId;

    public Material greenMat;
    public Material redMat;


    public int correctAnswerMultiplier = 2;
    private void Start()
    {
        TriviaEndEvents.triviaEndEvents.endTrivia += GetEndscore;
        correctAnswer.gameObject.GetComponent<Renderer>().material = greenMat;
        wrongAnswer.gameObject.GetComponent<Renderer>().material = redMat;
    }




    public void EnablePanels()
    {
        // questionText.text = questionScriptableObject.question;
       // correctAnswer.GetComponent<Material>().color = Color.green;
        //wrongAnswer.GetComponent<Material>().color = Color.red;
        questionText.gameObject.SetActive(true);
        correctAnswer.gameObject.SetActive(true);
        wrongAnswer.gameObject.SetActive(true);
    }

    public void ConvertCollected()
    {
        MyMoney._money.AddMoney(correctAnswer.collector*10 , correctAnswerMultiplier);
    }

    public void GetEndscore(int triviaId)
    {
        if (triviaId==_triviaId)
        {
            if (correctAnswer.collector > wrongAnswer.collector)
            {
                correctImage.gameObject.SetActive(true);

            }
            else
            {
                falseImage.gameObject.SetActive(true);
            }
            StartCoroutine(ImageCoroutine());
            _triviaId++;
        }
        else
        {
            Debug.Log("Trivia Id didnt match.");
        }
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
