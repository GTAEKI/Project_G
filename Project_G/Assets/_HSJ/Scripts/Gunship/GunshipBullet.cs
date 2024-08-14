using UnityEngine;
using System.Collections;
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

    private ParticleSystem.MainModule main;
    private ParticleSystem[] hitPSArray = new ParticleSystem[3];
    private ParticleSystem.MainModule[] hitmain = new ParticleSystem.MainModule[3];
    
    private Vector3 hitPSdir;
    
    EColorType colortype = EColorType.White;

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

    public void InitBulletColor(EColorType type = EColorType.White)
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
            Managers.Projectile.CreateHitFx();
            Managers.Projectile.Enqueue(this.gameObject, "Bullet");
        }
        if(other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            GameObject go = Managers.Projectile.CreateHitFx();            
            Managers.Projectile.Dequeue(other.ClosestPoint(transform.position) - hitPSdir,Quaternion.identity, "Bullet");
            Managers.Projectile.Enqueue(this.gameObject, "Bullet");

        }

        //hitPS.transform.position = other.ClosestPoint(transform.position) - hitPSdir;
        //hitPS.transform.forward = -hitPSdir;
        //hitPS.Play();
    }
    
       
     
}
