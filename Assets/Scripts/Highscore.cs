using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Highscore : MonoBehaviour
{
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI highScoreText;
    public Transform popupScore;

    [Range(0, 1)]
    public float TimeToSpawnUI;

    public int highScore = 0;
    public int currentScore = 0;
    float m_timer = 0;

    public GameObject uiBox;
    void Start()
    {
        highScore = PlayerPrefs.GetInt("Highscore", 0);
        highScoreText.text = highScore.ToString();
        uiBox.SetActive(false);
    }

    void Update()
    {
        if (OVRInput.Get(OVRInput.Touch.PrimaryTouchpad))
        {
            m_timer += Time.deltaTime;
            if(m_timer > TimeToSpawnUI)
                uiBox.SetActive(true);
        }
        else
        { 
            uiBox.SetActive(false);
            m_timer = 0.0f;
        }   
        
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
