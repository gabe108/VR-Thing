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
}
