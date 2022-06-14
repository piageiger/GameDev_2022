using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    [SerializeField] bool isHUD = true;

    [SerializeField] TextMeshProUGUI coinsTextEND;
    [SerializeField] TextMeshProUGUI scoreTextEND;
    [SerializeField] TextMeshProUGUI finalScoreTextEND;
    [SerializeField] TextMeshProUGUI bestScoreTextEND;

    [SerializeField] TextMeshProUGUI coinsTextHUD;
    [SerializeField] TextMeshProUGUI scoreTextHUD;
    [SerializeField] TextMeshProUGUI bestScoreTextHUD;

    public static int coins = 0;
    public static int score = 0;
    public static int bestScore = 0;
    public static int addFalldown = 0;

    private int finalScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        bestScore = PlayerPrefs.GetInt("bestScore", 0);
        if (isHUD) 
        {
            coinsTextHUD.text = "COINS: " + coins.ToString("0");
            scoreTextHUD.text = "SCORE: " + score.ToString("0");
            bestScoreTextHUD.text = "BESTSCORE: " + bestScore.ToString(); 
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //nehme den Wert von coinsTotal aus dem Skript CoinManager
        coins = CoinManager.coinsTotal;
        
        if (isHUD)
        {
            score = (int)(Time.time) + addFalldown;
            scoreTextHUD.text = "SCORE: " + score.ToString();
            coinsTextHUD.text = "COINS: " + coins.ToString();
        }
        else 
        {
            CalculateScore();   
        }
    }

    private void CalculateScore()
    {
        scoreTextEND.text = "Score: " + "+" + score.ToString();
        coinsTextEND.text = "Coins: " + "-" + coins.ToString(); 
        
        finalScore = score - coins;
        finalScoreTextEND.text = "Final Score: " + finalScore.ToString();

        //speichere BestScore wenn dieser kleiner ist als der errechnete EndScore
        if (finalScore < bestScore)
        {
            bestScore = finalScore;
            PlayerPrefs.SetInt("bestScore", bestScore);
        }
        bestScoreTextEND.text = "Best Score: " + bestScore.ToString(); 
    }
}
