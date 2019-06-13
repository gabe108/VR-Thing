using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BuildingState
{
    DEFAULT,
    PICKED_UP,
    DESTROYED,

    COUNT
}

public class BuildingController : MonoBehaviour
{
    public BuildingState m_state;
    public Collider m_collider;

    private void Start()
    {
        m_state = BuildingState.DEFAULT;
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
}
