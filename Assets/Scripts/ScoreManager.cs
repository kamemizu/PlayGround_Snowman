using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text _highscoreText;
    void Start()
    {
        float highScore = PlayerPrefs.GetInt("highscore", 0);
        _highscoreText.text = "HIGH SCORE: " + highScore.ToString();
    }
    public void SetHighScore(float value)
    {
        PlayerPrefs.SetFloat("highscore", value);
    }
}
