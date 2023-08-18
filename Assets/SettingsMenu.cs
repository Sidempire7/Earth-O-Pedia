using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    void Start()
    {
        if(!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volume",1);
            Load();
        }
        else
        {
            Load();
        }
    }
   /* public AudioMixer audioMixer;

    public void SetVolume(float volume)
    {
        volume=Mathf.Log10(volume)*20;
        if(volume==0f)
        {
            volume=-80f;
        }
        audioMixer.SetFloat("volume",volume);
    }*/
    public void ChangeVolume()
    {
        AudioListener.volume=volumeSlider.value;
        Save();
    }
    private void Load()
    {
        volumeSlider.value=PlayerPrefs.GetFloat("volume");
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("volume",volumeSlider.value);
    }

}
