using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    VrGrabber.VrgGrabber vrgGrabber;
    OVRManager manager;
    private Vector3 headHeight;

    void Start()
    {
        vrgGrabber = GameObject.Find("Vrg Right Grabber").GetComponent<VrGrabber.VrgGrabber>();
        manager = GameObject.Find("OVRCameraRig").GetComponent<OVRManager>();
        headHeight = manager.headPoseRelativeOffsetTranslation;
    }

    void Update()
    {
        //if (vrgGrabber.m_grabbedObject.CompareTag("Start"))
        //{
        //    Destroy(vrgGrabber.m_grabbedObject);
        //    StartCoroutine(wait());           
        //}

    }

    private IEnumerator wait()
    {
        while (true)
        {
            manager.headPoseRelativeOffsetTranslation += new Vector3(0, 0.03f, 0);

            if(manager.headPoseRelativeOffsetTranslation.y > 10)
                break;
            else
                yield return new WaitForSeconds(0.01f);
        }
        StartCoroutine(GameObject.FindObjectOfType<OVRScreenFade>().Fade(0, 1));
        yield return new WaitForSeconds(3f);
        manager.headPoseRelativeOffsetTranslation = headHeight;
        SceneManager.LoadScene(1);
        yield return null;
    }

}
