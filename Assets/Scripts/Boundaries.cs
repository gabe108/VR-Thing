using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<BaseObject>().m_state = ObjectStates.DESTROYED;
    }
}
