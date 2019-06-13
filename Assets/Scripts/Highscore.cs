using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{

    public Text currentScoreText;
    public Text highScoreText;

    private int highScore = 0;
    private int currentScore = 0;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("Highscore", 0);
        highScoreText.text = highScore.ToString();
    }

    void Update()
    {
        currentScoreText.text = currentScore.ToString();

        if(currentScore > highScore)
        {
            highScore = currentScore;
            highScoreText.text = highScore.ToString();
        }
    }

    //Called anytime this object is disabled (changing scenes and quitting app)
    private void OnDisable()
    {
        PlayerPrefs.SetInt("Highscore", highScore);
        PlayerPrefs.Save();
    }
}
