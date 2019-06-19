using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VrGrabber;

public enum ObjectStates
{
    DEFAULT,
    GRABBED,
    RELEASED,
    DESTROYED,

    COUNT
}

public class BaseObject : VrgGrabbable
{
    public ObjectStates m_state;
    public int points;

    [HideInInspector]
    public float dist;
    [HideInInspector]
    public Transform player;
    [HideInInspector]
    public Score scoreBoard;

    private void Start()
    {
        m_state = ObjectStates.DEFAULT;
        player = GameObject.Find("OVRCameraRig").transform;
        scoreBoard = player.GetComponent<Score>();
        baseObj = this;
    }

    public void UpdateFurthestThrow()
    {
        Rigidbody rb = transform.GetComponent<Rigidbody>();

        if (rb.velocity != Vector3.zero && transform.position.y > -2)
        {
            dist = Vector3.Distance(transform.position, player.position);
        }
        else if(rb.velocity == Vector3.zero)
        {
            m_state = ObjectStates.DEFAULT;
        }
        else if (transform.position.y < -2)
        {
            m_state = ObjectStates.DESTROYED;
        }

        scoreBoard.currentThrow = (int)dist;        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Ground"))
            return;

        if (collision.transform.CompareTag("Hoop"))
        {
            collision.transform.GetComponent<Hoop>().play = true;
            m_state = ObjectStates.DESTROYED;
            return;
        }

        BaseObject obj = collision.gameObject.GetComponent<BaseObject>();
        obj.m_state = ObjectStates.DESTROYED;
    }
}
