using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YeetToStart : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<BaseObject>().m_state = ObjectStates.DESTROYED;
        StartCoroutine(wait());
    }
    private IEnumerator wait()
    {
        StartCoroutine(GameObject.FindObjectOfType<OVRScreenFade>().Fade(0, 1));
        yield return new WaitForSeconds(3f);
        PlayerPrefs.Save();
        SceneManager.LoadScene(1);
        yield return null;
    }
}
