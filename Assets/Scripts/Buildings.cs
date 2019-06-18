using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Buildings : BaseObject
{
    public Transform popupText;
    public ParticleSystem destructionParticle;
    public ParticleSystem ParticleReference;
    public int destroyScore;

    bool scorePopped = false;

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

                if (!scorePopped)
                {
                    Vector3 temp = transform.position;
                    Transform g = Instantiate(popupText, temp, Quaternion.identity, null);
                    ParticleReference = Instantiate(destructionParticle, temp, Quaternion.identity, null);
                    g.GetComponent<TextMeshPro>().text = destroyScore.ToString();
                    scoreBoard.currentScore += destroyScore;
                    scorePopped = true;
                }
                Destroy(gameObject, 1f);
                break;

            default:

                break;
        }
    }
}
