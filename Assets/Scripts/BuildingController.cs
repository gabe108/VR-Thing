using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum BuildingState
{
    DEFAULT,
    PICKED_UP,
    RELEASED,
    DESTROYED,

    COUNT
}

public class BuildingController : MonoBehaviour
{
    public int destroyScore;
    public Transform popupText;
    public BuildingState m_state;
    public float currentThrow;
    public float furthestThrow;
    public TextMeshProUGUI FurthestScore;
    public TextMeshProUGUI CurrentThrowScore;

    Highscore highScore;

    private void Awake()
    {
        FurthestScore = GameObject.Find("FurthestScore").GetComponent<TextMeshProUGUI>();
        CurrentThrowScore = GameObject.Find("CurrentThrowScore").GetComponent<TextMeshProUGUI>();
    }

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

            case BuildingState.RELEASED:
                UpdateFurthestThrow();
                break;

            case BuildingState.DESTROYED:
                Destroy(gameObject, 1f);
                break;

            default:

                break;
        }
    }

    public void UpdateFurthestThrow()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        float dist = 0;
        if (rb.velocity != Vector3.zero || transform.position.y > 0)
        {
            dist = Vector3.Distance(transform.position, highScore.transform.position);
        }

        currentThrow = dist;
        if (currentThrow > furthestThrow)
            furthestThrow = currentThrow;

        CurrentThrowScore.text = currentThrow.ToString();
        FurthestScore.text = furthestThrow.ToString();

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
        temp.y -= 0.5f;
        Transform g = Instantiate(popupText, temp, Quaternion.identity, null);
        g.GetComponent<TextMeshPro>().text = destroyScore.ToString();
        highScore.currentScore += destroyScore;
    }
}
