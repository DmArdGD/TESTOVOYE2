using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TMP_Text HighscoreText;
    [SerializeField] TMP_Text ScoreText;

    public static int score;
    public static int highscore;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("SaveScore"))
        highscore = PlayerPrefs.GetInt("SaveScore");
    }
    void Start()
    {
         score = 0;
    }

    void Update()
    {
        ScoreText.text = score.ToString();
        HighscoreText.text = highscore.ToString();
       
    }

    public void AddScore()
    {
        score++;    
        HighScore();        
    }

    public void HighScore()
    {
        if(score >= highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("SaveScore", highscore);
        }
    }
}
