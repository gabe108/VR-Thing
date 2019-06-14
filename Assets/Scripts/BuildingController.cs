using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum BuildingState
{
    DEFAULT,
    PICKED_UP,
    DESTROYED,

    COUNT
}

public class BuildingController : MonoBehaviour
{
    public int destroyScore;
    public Transform popupText;
    public BuildingState m_state;

    Highscore highScore;    

    private void Start()
    {
        m_state = BuildingState.DEFAULT;
        highScore = GameObject.Find("OVRCameraRig").GetComponent<Highscore>();
    }

    private void Update()
    {
        switch (m_state)
        {
            case BuildingState.DEFAULT:

                break;

            case BuildingState.PICKED_UP:

                break;

            case BuildingState.DESTROYED:
                Destroy(gameObject, 1f);
                break;

            default:

                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Building"))
        {
            BuildingController bc = collision.gameObject.GetComponent<BuildingController>();
            bc.m_state = BuildingState.DESTROYED;
        }
    }

    private void OnDestroy()
    {
        Vector3 temp = transform.position;
        temp.y += 0.5f;
        Transform g = Instantiate(popupText, temp, Quaternion.identity, null);
        g.GetComponent<TextMeshPro>().text = destroyScore.ToString();
        highScore.currentScore += destroyScore;
    }
}
