using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class GunshipBullet : MonoBehaviour
{
    #region SerializeField
    [SerializeField]
    private ParticleSystem hitPS;

    [SerializeField]
    private ParticleSystem bulletPS;
    [SerializeField]
    private Light bulletLight;
    [SerializeField]
    private Rigidbody rigid;
    #endregion

    #region Colors 
    [SerializeField]
    [ColorUsage(false,false)]
    private Color White;
    [SerializeField]
    [ColorUsage(false, false)]
    private Color Red;
    [SerializeField]
    [ColorUsage(false, false)]
    private Color Yellow;
    #endregion

    public float Damage { get; private set; } = 10f;

    private const string default_Bulletcolor = "White";
    private ParticleSystem.MainModule main;
    private ParticleSystem[] hitPSArray = new ParticleSystem[3];
    private ParticleSystem.MainModule[] hitmain = new ParticleSystem.MainModule[3];
    
    private Vector3 hitPSdir;
    
    // test 용
    // 추후 병합 후 Define으로 변경할것 

    EColorType colortype = EColorType.None;
    //


    void Awake()
    {
        // Get ParticleSystem Mainmodule
        main = bulletPS.main;

        hitPSArray = hitPS.GetComponentsInChildren<ParticleSystem>();
        for(int i = 0; i < hitPSArray.Length; i++)
        {
            hitmain[i] = hitPSArray[i].main;
        }
    }

    public void InitBulletColor(EColorType type = EColorType.None)
    {
        switch (type)
        {
            case EColorType.Red:
                colortype = EColorType.Red;
                main.startColor = Red;
                bulletLight.color = Red;
                for (int i = 0; i < hitmain.Length; i++)
                {
                    hitmain[i].startColor = Red;
                }
                break;
            case EColorType.Yellow:
                colortype = EColorType.Yellow;
                main.startColor = Yellow;
                bulletLight.color = Yellow;
                for (int i = 0; i < hitmain.Length; i++)
                {
                    hitmain[i].startColor = Yellow;
                }
                break;
            default:
                colortype = EColorType.White;
                main.startColor = White;
                bulletLight.color = White;
                for (int i = 0; i < hitmain.Length; i++)
                {
                    hitmain[i].startColor = White;
                }
                break;
        }        
    }

    public void ShotBullet(Vector3 dir, float bulletSpeed)
    {
        hitPSdir = dir;
        rigid.AddForce(dir * bulletSpeed, ForceMode.VelocityChange);
    }

    void OnTriggerEnter(Collider other)
    {        
        if (other.TryGetComponent(out Enemy enemy))
        {
            enemy.CalDamage(Damage, colortype);
            Debug.Log("Hit Enemy");
        }

        rigid.constraints = RigidbodyConstraints.FreezePosition;
        hitPS.transform.position = other.ClosestPoint(transform.position) - hitPSdir;
        hitPS.transform.forward = -hitPSdir;
        hitPS.Play();
    }
    
       
     
}
