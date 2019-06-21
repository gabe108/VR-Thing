using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public GameObject uiBox;
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI currentThrowText;
    public TextMeshProUGUI furthestThrowText;

    public int furthestThrow;
    public int currentThrow;    
    public int highScore = 0;
    public int currentScore = 0;
    float m_timer = 0;
    bool hasSetScores = false;

    [Range(0, 1)]
    public float TimeToSpawnUI;

    private void Awake()
    {
        uiBox = GameObject.Find("Score");
    }

    void Start()
    {
        uiBox.SetActive(false);
        highScore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = highScore.ToString();
        furthestThrow = PlayerPrefs.GetInt("FurthestThrow");
        furthestThrowText.text = furthestThrow.ToString();

        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            currentScore = PlayerPrefs.GetInt("CurrentScore");
            currentThrow = PlayerPrefs.GetInt("CurrentThrow");
        }
    }

    void Update()
    {   

        if (OVRInput.Get(OVRInput.Touch.PrimaryTouchpad) || Input.GetKey(KeyCode.A))
        {
            m_timer += Time.deltaTime;
            if (m_timer > TimeToSpawnUI)
                uiBox.SetActive(true);
        }
        else
        {
            uiBox.SetActive(false);
            m_timer = 0.0f;
        }

        currentScoreText.text = currentScore.ToString();
        PlayerPrefs.SetInt("CurrentScore", currentScore);

        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            highScoreText.text = highScore.ToString();
            hasSetScores = true;
        }

        currentThrowText.text = currentThrow.ToString();
        PlayerPrefs.SetInt("CurrentThrow", currentThrow);

        if (currentThrow > furthestThrow)
        {
            furthestThrow = currentThrow;
            PlayerPrefs.SetInt("FurthestThrow", currentThrow);
            furthestThrowText.text = furthestThrow.ToString();
            hasSetScores = true;
        }
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetInt("HighScore", 0));
    }
}
