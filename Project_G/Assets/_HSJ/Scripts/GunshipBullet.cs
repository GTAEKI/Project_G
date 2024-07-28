using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    private const string default_Bulletcolor = "White";
    private ParticleSystem.MainModule main;
    private Vector3 hitPSdir;
    
    // test 용
    // 추후 병합 후 Define으로 변경할것 
    public enum ECOLOR_TYPE
    {
        NONE, WHITE, RED, YELLOW
    }
    ECOLOR_TYPE colortype = ECOLOR_TYPE.NONE;
    //


    void Awake()
    {
        // Get ParticleSystem Mainmodule
        main = bulletPS.main;
    }

    public void InitBulletColor(string type = default_Bulletcolor)
    {

        switch (type)
        {
            case "White":
                colortype = ECOLOR_TYPE.WHITE;
                main.startColor = White;
                bulletLight.color = White;
                break;
            case "Red":
                colortype = ECOLOR_TYPE.RED;
                main.startColor = Red;
                bulletLight.color = Red;
                break;
            case "Yellow":
                colortype = ECOLOR_TYPE.YELLOW;
                main.startColor = Yellow;
                bulletLight.color = Yellow;
                break;
            default:
                main.startColor = White;
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
            // 병합후 처리
            // 매개 변수로 type을 전달
            //enemy.CalDamage();
        }
        rigid.constraints = RigidbodyConstraints.FreezePosition;
        hitPS.transform.position = other.ClosestPoint(transform.position) - hitPSdir ;
        hitPS.transform.forward = -hitPSdir;
        hitPS.Play();
        
    }
    
       
     
}
