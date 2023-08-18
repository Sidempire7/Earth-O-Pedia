using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(menuName="Quiz Question",fileName="New Question")]

public class QuestionSO : ScriptableObject
{
    [TextArea(2,6)]
    [SerializeField] string question="ENTER NEW QUESTION HERE";
   // [SerializeField] Sprite Imageq;
    [SerializeField] string[] answers=new string[4];
    [SerializeField] int correctAnswerIndex;

    
   // public Sprite GetImage()
   // {
   //     return Imageq;
   // }
    public string GetQuestion()
    {
        return question;
    }

    public string GetAnswer(int index)
    {
        return answers[index];
    }

    public int GetCorrectAnswerIndex()
    {
        return correctAnswerIndex;
    }
}

