using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private GameObject playerPrefab;

    [SerializeField]
    private GameObject pauseMenu;

    [SerializeField]
    private GameObject gameOverMenu;    

    [SerializeField]
    private GameObject canvas;    

    [SerializeField]
    private GameObject settingsMenu; 

    public static bool zielErreicht = false;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

    }

    private void Start()
    {
        StartGame();
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            canvas.SetActive(!canvas.activeInHierarchy);
            if (canvas.activeInHierarchy)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
                settingsMenu.SetActive(false);
            }
        }

        if(zielErreicht)
        {
            ShowGameOverMenu();            
        }

    }

    public void StartGame()
    {
        Debug.Log("starting Game");
        Time.timeScale = 1;
        canvas.SetActive(false);
        Debug.Log("canvas off");
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);  
        //settingsMenu.SetActive(false);      
    }

    public void ShowGameOverMenu()
    {
        canvas.SetActive(true);
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(true);        
        Time.timeScale = 0;
        
    }

}
