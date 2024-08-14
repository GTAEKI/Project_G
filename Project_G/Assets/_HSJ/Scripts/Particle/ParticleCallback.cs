using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCallback : MonoBehaviour
{
    ParticleSystem main;
    void Start()
    {
        main = GetComponent<ParticleSystem>();
    }

    public void OnParticleSystemStopped()
    {
        main.Stop();
        Managers.Projectile.Enqueue(this.gameObject,"Fx");
    } 

}
