using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCallback : MonoBehaviour
{
    ParticleSystem main;
    void Awake()
    {
        main = GetComponent<ParticleSystem>();
        Debug.Log(main == null);
    }
    void OnEnable()
    {
        main.Play();
    }
    public void OnParticleSystemStopped()
    {
        
        Debug.Log($"particle pos : {gameObject.transform.position}");
        Managers.Projectile.Enqueue(this.gameObject,"Fx");
        gameObject.SetActive(false);
    } 

}
