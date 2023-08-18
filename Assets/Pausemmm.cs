using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Pausemmm : MonoBehaviour
{
    public GameObject menuPanel;
    
    public static bool GameIsPaused=false;

    
    public void ResumeGame()
    {
        menuPanel.SetActive(false);
        Time.timeScale=1f;
        // SoundManager.Instance.PlaySound("Countdown");

        GameIsPaused=false;
    }

    public void MenuBack()
    {
        
        SceneManager.LoadScene("Menu");
        Time.timeScale=1f;
        Debug.Log("READY STATE");
        
      
    }
         public void QuitGamee()
    {
        Debug.Log("EXITED");
        Application.Quit();
    }

    }
    
    

