using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeLeft = 60.0f;
    public TextMeshProUGUI timerText;

    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Background");
    }

    void Update()
    {
        timerText.text = timeLeft.ToString();

        timeLeft -= Time.deltaTime;
        if (timeLeft < 0 )
            GameOver();
    }

    void GameOver()
    {       
        SceneManager.LoadScene(2);
    }
}
