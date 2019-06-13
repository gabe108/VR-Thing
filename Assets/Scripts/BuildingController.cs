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
    private void OnTriggerEnter(Collider other)
    {
        
    }
}
