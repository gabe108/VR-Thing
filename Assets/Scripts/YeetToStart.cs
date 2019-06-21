using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YeetToStart : MonoBehaviour
{
    public Scene m_game;
    public Scene m_mainMenu;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("StartText"))
            StartCoroutine(wait());
        if (other.CompareTag("Quit"))
            Application.Quit();
        if (other.CompareTag("Menu"))
            StartCoroutine(Menu());
    }
    private IEnumerator wait()
    {
        StartCoroutine(GameObject.FindObjectOfType<OVRScreenFade>().Fade(0, 1));
        yield return new WaitForSeconds(3f);
        PlayerPrefs.Save();
        SceneManager.LoadScene(m_game.buildIndex);
        yield return null;
    }

    private IEnumerator Menu()
    {
        StartCoroutine(GameObject.FindObjectOfType<OVRScreenFade>().Fade(0, 1));
        yield return new WaitForSeconds(3f);
        PlayerPrefs.Save();
        SceneManager.LoadScene(m_mainMenu.buildIndex);
        yield return null;
    }
}
