using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    VrGrabber.VrgGrabber vrgGrabber;

    void Start()
    {
        vrgGrabber = GameObject.Find("VrGrabber").GetComponent<VrGrabber.VrgGrabber>();
    }

    void Update()
    {        
        if (Input.GetKey(KeyCode.P))
        {
            //Destroy(vrgGrabber.m_grabbedObject.gameObject);
            StartCoroutine(wait());
        }

        if (vrgGrabber.m_grabbedObject == null)
            return;
        else if (vrgGrabber.m_grabbedObject.CompareTag("Start"))
        {
            Destroy(vrgGrabber.m_grabbedObject.gameObject);
            StartCoroutine(wait());           
        }
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
