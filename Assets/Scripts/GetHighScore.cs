using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GetHighScore : MonoBehaviour
{
    public TMP_Text Highscore_Text;
    
    private void Awake()
    {
        if (PlayerPrefs.HasKey("SaveScore"))
       ScoreCounter.HighScoreEnemys = PlayerPrefs.GetInt("SaveScore");
        
    }
    private void Update()
    {
        Highscore_Text.text = ScoreCounter.HighScoreEnemys.ToString();
    }
}
