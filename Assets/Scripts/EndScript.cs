using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EndScript : MonoBehaviour
{
   [SerializeField] TextMeshProUGUI finalScoreText;
   
    ScoreKeeper scoreKeeper;
    public Button end;

    void Start()
    {
        
       scoreKeeper=FindObjectOfType<ScoreKeeper>(); 
    }
    public void ShowFinalScore()
    {
        
        finalScoreText.text="Congratulations!\nYou got a score of "+ scoreKeeper.CalculateScore()+"%";
    }
}
    
