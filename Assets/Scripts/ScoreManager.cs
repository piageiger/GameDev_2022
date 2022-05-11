using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highscoreText;

    int score = 0;
    int highscore = 0;

    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = "SCORE: " + score.ToString();
        highscoreText.text = "HIGHSCORE: "+highscore.ToString(); 
        
    }

    // Update is called once per frame
    void Update()
    {
        //nehme den Wert von countCoin aus dem Skript CoinCollect
        score = CoinCollect.countCoin;
        scoreText.text = "SCORE: " + score.ToString();
        //speichere Highscore wenn dieser kleiner ist als der Score
        if(score > highscore)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
        
        
    }
}
