using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestionScriptableObject",menuName ="Scriptable Objects/QuestionScriptableObject")]
public class QuestionScriptableObject : ScriptableObject
{
    public string question;

    public string correctAnswer;

    public string wrongAnswer;

}
