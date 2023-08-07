using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public TMP_Text Score;
    public TMP_Text HighScore;
    public static int ScoreEnemys;
    public static int HighScoreEnemys;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("SaveScore"))
            HighScoreEnemys = PlayerPrefs.GetInt("SaveScore");
    }
    public void Update()
    {
        Score.text = ScoreEnemys.ToString();
        HighScore.text = HighScoreEnemys.ToString();

        if (ScoreEnemys >= HighScoreEnemys)
        {
            HighScoreEnemys = ScoreEnemys;
            PlayerPrefs.SetInt("SaveScore", HighScoreEnemys);
        }
    }

    
}
