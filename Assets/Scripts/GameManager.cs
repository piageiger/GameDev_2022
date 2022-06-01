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

    [SerializeField]
    private GameObject deathScreen;

    public static bool zielErreicht;
    public static bool died;

    private void Awake()
    {
        if (Instance == null)
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
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            pauseMenu.SetActive(!pauseMenu.activeInHierarchy);
            if (pauseMenu.activeInHierarchy)
            {
                Time.timeScale = 0f;
<<<<<<< Updated upstream
=======
                deathScreen.SetActive(false);
>>>>>>> Stashed changes
            }
            else
            {
                Time.timeScale = 1f;
            }
        }

        if (zielErreicht)
        {
            gameOverMenu.SetActive(true);
            Time.timeScale = 0f;
<<<<<<< Updated upstream
=======
        }

        if((died) && (!pauseMenu.activeInHierarchy))
        {
            deathScreen.SetActive(true);
            Invoke("HideDeathScreen", 2.0f);
>>>>>>> Stashed changes
        }

    }

    public void StartGame()
    {
        Time.timeScale = 1;
    }

    private void HideDeathScreen()
    {
        died = false;
        deathScreen.SetActive(false);
    }
}