using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuPanel;
    public static bool GameIsPaused=false;

    public void ShowMenuPanel()
    {
        pauseMenuPanel.SetActive(true);
        
        Time.timeScale=0f;
       // SoundManager.Instance.StopSound("Countdown");
        Debug.Log("PASUE STATE");
        GameIsPaused=true;
    }
}
