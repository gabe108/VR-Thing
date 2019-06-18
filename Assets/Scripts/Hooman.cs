using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hooman : BaseObject
{
    private void Update()
    {
        switch (m_state)
        {
            case ObjectStates.DEFAULT:

                break;

            case ObjectStates.GRABBED:

                break;

            case ObjectStates.RELEASED:
                UpdateFurthestThrow();
                break;

            case ObjectStates.DESTROYED:
                Destroy(gameObject, 1f);
                break;

            default:

                break;
        }
    }
}
