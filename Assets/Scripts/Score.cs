using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public GameObject uiBox;
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI currentThrowText;
    public TextMeshProUGUI furthestThrowText;

    public float furthestThrow;
    public float currentThrow;    
    public int highScore = 0;
    public int currentScore = 0;
    float m_timer = 0;

    [Range(0, 1)]
    public float TimeToSpawnUI;

    private void Awake()
    {
        uiBox = GameObject.Find("Score");
    }

    void Start()
    {
        uiBox.SetActive(false);
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
            //uiBox.SetActive(false);
            m_timer = 0.0f;
        }

        if (currentScoreText.gameObject.activeSelf &&
            highScoreText.gameObject.activeSelf &&
            currentThrowText.gameObject.activeSelf &&
            furthestThrowText.gameObject.activeSelf)
        {
            currentScoreText.text = currentScore.ToString();

            if (currentScore > highScore)
            {
                highScore = currentScore;
                highScoreText.text = highScore.ToString();
            }

            currentThrowText.text = currentThrow.ToString();

            if (currentThrow > furthestThrow)
            {
                furthestThrow = currentThrow;
                furthestThrowText.text = furthestThrow.ToString();
            }
        }
    }
}
