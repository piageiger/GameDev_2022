using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    //[SerializeField]
    private GameObject playerPrefab;

    [SerializeField]
    private GameObject pauseMenu;

    //[serializefield]
    //private menucontroller menucontroller;

    //public GameObject PlayerObject;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        //SpawnPlayer();
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            pauseMenu.SetActive(!pauseMenu.activeInHierarchy);
            if (pauseMenu.activeInHierarchy)
            {
                PauseGame();
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void SpawnPlayer()
    {
       //PlayerObject = Instantiate(playerPrefab);
      
    }

    public void DestroyPlayer()
    {
        //Destroy(PlayerObject);
    }
}
