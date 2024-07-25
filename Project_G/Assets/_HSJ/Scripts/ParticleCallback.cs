using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCallback : MonoBehaviour
{
    public void OnParticleSystemStopped()
    {
        Debug.Log("Stop");
    }
}
