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
    private GameObject settingsMenu; 

    public static bool zielErreicht;

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
        zielErreicht = false;
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            pauseMenu.SetActive(!pauseMenu.activeInHierarchy);
            if (pauseMenu.activeInHierarchy)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }

        if(zielErreicht)
        {
            Debug.Log("ZielErreicht!");
            gameOverMenu.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            gameOverMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void StartGame()
    {
        Debug.Log("starting Game");
        Time.timeScale = 1; 
    }
}
