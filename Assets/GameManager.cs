using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Quiz quiz;
    EndScreen endScreen;

    

    void Awake()
    {
        
         quiz=FindObjectOfType<Quiz>();
       endScreen=FindObjectOfType<EndScreen>();
    }
    void Start()
    {
       
        
        quiz.gameObject.SetActive(true);
        endScreen.gameObject.SetActive(false);
    
    }

   
    void Update()
    {
        if(quiz.isComplete)
        {
            quiz.gameObject.SetActive(false);
            endScreen.gameObject.SetActive(true);
            endScreen.ShowFinalScore();
            
        }
        
    }
    public void OnReplayLevel()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        

    }
    public void QuitGamee()
    {
        Debug.Log("EXITED");
        Application.Quit();
    }
    
     

    public void LoadMenu()
    {
        
        
        Time.timeScale=1f;
        SceneManager.LoadScene(0);
        Debug.Log("MAIN MENU");
    }

  
    
    
    
}
