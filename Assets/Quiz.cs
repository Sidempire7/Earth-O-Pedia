using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] List<AudioSource> sounds=new List<AudioSource>();

    [Header("Question")]
    [SerializeField] QuestionSO currentquestion;
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] List<QuestionSO> questions=new List<QuestionSO>();

    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;
    int correctAnswerIndex;
    bool hasAnswerEarly=true;

    [Header("Button Colors")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;
    

    [Header("Scoring")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    [Header("ProgressBar")]
    [SerializeField] Slider progressBar;

    public bool isComplete;

    public bool playsound;
     float timerValue;
    public bool isAnswer;
    //public AudioClip IncorrectSFX;
    public bool Please=true;//trying
   Button button1;
   // public AudioSource Source;
   Quiz quiz;
    
    void Awake()
    {
        
      // FindObjectOfType<AudioManager>().Play("Background");
       // SoundManager.Instance.StopSound("CorrectSFX");
       Debug.Log("HELLO");
        // FindObjectOfType<AudioManager>().Stop("IncorrectSFX"); maywork
        // FindObjectOfType<AudioManager>().Stop("CorrectSFX"); maywork
        
        //SoundManager.Instance.StopSound("IncorrectSFX");//


        timer=FindObjectOfType<Timer>();
        scoreKeeper=FindObjectOfType<ScoreKeeper>();
        progressBar.maxValue=questions.Count;
        progressBar.value=0;
    }
    
    void Update()
    {
                        
        timerImage.fillAmount=timer.fillFraction;
        if(timer.loadNextQuestion)
        {
            Please=false;
            if(progressBar.value==progressBar.maxValue)
            {
                isComplete=true;
                return;
            }
            
            hasAnswerEarly=false;
            GetNextQuestion();
            timer.loadNextQuestion=false;
            
            
        }
        
        else if(!hasAnswerEarly && !timer.isAnsweringQuestion)
        {   
            
           if (Please==true)
           {
        //    FindObjectOfType<AudioManager>().Play("IncorrectSFX");//TRYING
            Please=false;
           }
             DisplayAnswer(-1);
            SetButtonState(false); 
     }
     else if(!hasAnswerEarly)
     {
        Please=true;
        Debug.Log("NO ANSWER");
     }

        
        
        
       

    }
    public void OnAnswerSelected(int index)
    {
        //SoundManager.Instance.StopSound("Countdown");
        hasAnswerEarly=true;
        
        DisplayAnswer(index);
        SetButtonState(false);
        timer.CancelTimer();
        scoreText.text="Score: "+scoreKeeper.CalculateScore()+"%";
        
    }
    void DisplayAnswer(int index)
       {
            
            Image buttonImage;
            //SoundManager.Instance.StopSound("Countdown");
       if(index==currentquestion.GetCorrectAnswerIndex())
        {
           isAnswer=true;
           if(isAnswer)
            {
                Debug.Log("CORRECT ASNWER");
              //  SoundManager.Instance.StopSound("TimeUp");
            //   FindObjectOfType<AudioManager>().Stop("IncorrectSFX");
            //   FindObjectOfType<AudioManager>().Play("CorrectSFX");
              //  SoundManager.Instance.PlaySound("CorrectSFX");
            }
            
            questionText.text="                       Correct Answer!";
            buttonImage=answerButtons[index].GetComponent<Image>();
            buttonImage.sprite=correctAnswerSprite;
            scoreKeeper.IncrementCorrectAnswers();
        }
        else
        {
            if(Please==true)
            {
                Debug.Log("WHATTTT");
               //SoundManager.Instance.PlaySound("IncorrectSFX");
            //    FindObjectOfType<AudioManager>().Play("IncorrectSFX");
                Please=false;
            }
            isAnswer=false;
            if(!isAnswer && Please==true)
            {
                Debug.Log(" WRONG ASNWER");
               // SoundManager.Instance.StopSound("TimeUp");
            //    FindObjectOfType<AudioManager>().Stop("IncorrectSFX");
               // SoundManager.Instance.PlaySound("IncorrectSFX");
            }
            correctAnswerIndex=currentquestion.GetCorrectAnswerIndex();
            string correctAnswer=currentquestion.GetAnswer(correctAnswerIndex);
           
            questionText.text="          Wrong! The correct answer was:\n";
            buttonImage=answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite=correctAnswerSprite;
        }
       
        }
    void GetNextQuestion()
    {
        if(questions.Count>0)
        {
            
           // SoundManager.Instance.StopSound("IncorrectSFX");
        //    FindObjectOfType<AudioManager>().Stop("IncorrectSFX");
            SetButtonState(true); 
            SetDefaultButtonSprites();
            GetRandomQuestion();
            DisplayQuestion();
            progressBar.value++;
            scoreKeeper.IncrementQuestionsSeen();
        }
    }

    void GetRandomQuestion()
    {
        int index=Random.Range(0,questions.Count);
        currentquestion=questions[index];
        if(questions.Contains(currentquestion))
        {
            questions.Remove(currentquestion);
        }
    }
    void DisplayQuestion()
    {   
        playsound=true;
        if(playsound==true)
        {
          //  SoundManager.Instance.PlaySound("Countdown");
        }
       
        questionText.text=currentquestion.GetQuestion();
        
        
        for(int i=0;i<answerButtons.Length;i++)
        {

            TextMeshProUGUI buttonText=answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text=currentquestion.GetAnswer(i);
        }
    }
    void SetButtonState(bool state)
    {
        for(int i=0;i<answerButtons.Length;i++)
        {
            Button button=answerButtons[i].GetComponent<Button>();
            button.interactable=state;
        }
    
        
    }
    void SetDefaultButtonSprites()
    {
        for(int i=0;i<answerButtons.Length;i++)
        {
            Image buttonImage=answerButtons[i].GetComponent<Image>();
            buttonImage.sprite=defaultAnswerSprite;
        }
    }
}
