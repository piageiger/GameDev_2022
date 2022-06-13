using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI coinsText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI bestScoreText;

    public static int coins = 0;
    public static int score = 0;
    public static int bestScore = 0;
    public static int addFalldown = 0;

    // Start is called before the first frame update
    void Start()
    {
        bestScore = PlayerPrefs.GetInt("bestScore", 0);
        coinsText.text = "COINS: " + coins.ToString("0");
        scoreText.text = "SCORE: " + score.ToString("0");
        bestScoreText.text = "BESTSCORE: "+ bestScore.ToString(); 
        
    }

    // Update is called once per frame
    void Update()
    {
        score = (int)(Time.time) + addFalldown;
        scoreText.text = "SCORE: " + score.ToString();

        //nehme den Wert von coinsTotal aus dem Skript CoinManager
        coins = CoinManager.coinsTotal;
        coinsText.text = "COINS: " + coins.ToString();
    }

    public void CalculateScore()
    {
        score -= coins;

        //speichere BestScore wenn dieser kleiner ist als der Score
        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("bestScore", score);
        }
    }
}
