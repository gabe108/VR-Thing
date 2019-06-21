using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUpText : MonoBehaviour
{
    public Transform MyCameraTransform;
    private Transform MyTransform;
    public bool alignNotLook = true;

    TextMeshPro text;

    // Use this for initialization
    void Start()
    {
        MyTransform = this.transform;
        MyCameraTransform = GameObject.Find("CenterEyeAnchor").transform;

        MyCameraTransform = Camera.main.transform;
        if (alignNotLook)
            MyTransform.forward = MyCameraTransform.forward;
        else
            MyTransform.LookAt(MyCameraTransform, Vector3.up);

        Destroy(transform.gameObject, 1f);
    }
}
