using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionParticle : MonoBehaviour
{
    void Start()
    {
        Destroy(transform.gameObject, 7f);
        Invoke("StopParticles", 1f);
    }
    
    void StopParticles()
    {
        transform.GetComponent<ParticleSystem>().Stop(true);
    }
}
