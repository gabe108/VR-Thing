using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoop : MonoBehaviour
{
    public List<ParticleSystem> systems;
    public bool play;

    float m_timer = 0;
    private void Start()
    {
        systems[0].Stop(true);
    }

    private void Update()
    {
        if (play)
        {
            systems[0].Play(true);
            play = false;
            Invoke("StopParticles", 3);
        }
    }

    void StopParticles()
    {
        systems[0].Stop(true);
    }
}
