using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public GameObject settingsMenu;
    public GameObject canvas;
    public GameObject deathScreen;
    public AudioMixer audioMixer;
    

    public void CloseMenu()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void OpenSettings()
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void CloseSettings()
    {
        pauseMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", volume);
    }

    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume);
    }


    public void RestartGame()
    {
        ScoreManager.restart = true;
        SceneManager.LoadScene("Game");
    }


    public void QuitGame()
    {
        //ThirdPersonMovement.checkPointNr = 0;
        PlayerPrefs.SetInt("checkPointNr", 0);
        Application.Quit();
    }

    public void BackToMainMenu()
    {
        PlayerPrefs.SetInt("checkPointNr", 0);
        SceneManager.LoadScene("Mainmenu");
    }
}
