using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    VrGrabber.VrgGrabber vrgGrabber;
    private Vector3 headHeight;

    void Start()
    {
        vrgGrabber = GameObject.Find("Vrg Right Grabber").GetComponent<VrGrabber.VrgGrabber>();
    }

    void Update()
    {
        if (vrgGrabber.m_grabbedObject.CompareTag("Start"))
        {
            Destroy(vrgGrabber.m_grabbedObject.gameObject);
            StartCoroutine(wait());           
        }
    }

    private IEnumerator wait()
    {
        StartCoroutine(GameObject.FindObjectOfType<OVRScreenFade>().Fade(0, 1));
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(1);
        yield return null;
    }
}
