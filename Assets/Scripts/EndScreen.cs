using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndScreen : MonoBehaviour
{
   [SerializeField] TextMeshProUGUI finalScoreText;
    ScoreKeeper scoreKeeper;
    public GameObject end;
    
    void Awake()
    {
        
       scoreKeeper=FindObjectOfType<ScoreKeeper>(); 
       
    }
    public void ShowFinalScore()
    {
        
        end.SetActive(false);
        
        finalScoreText.text="Congratulations!\nYou got a score of "+ scoreKeeper.CalculateScore()+"%";
       
    }
    
}
    
