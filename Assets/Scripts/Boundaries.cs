using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Building") || other.CompareTag("Water"))
            return;

        other.GetComponent<BaseObject>().m_state = ObjectStates.DESTROYED;
    }
}
