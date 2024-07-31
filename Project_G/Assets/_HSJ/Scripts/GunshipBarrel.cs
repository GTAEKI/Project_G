using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class GunshipBarrel : MonoBehaviour
{

    #region SerializedField
    [SerializeField]
    private Camera gameCamera;
    [SerializeField]
    private GameInput gameInput;
    [SerializeField]
    private ParticleSystem flashParticle;
    #endregion

    private ResourceManager resource;
    private GameObject bullet;
    private Vector3 bottomLeftScreen;
    private Vector3 bottomLeftWorld;

    
    private float bulletSpeed = 25f;

    [field: SerializeField]
    public EColorType BulletType { get; private set; } = EColorType.None;
    void Start()
    {
        Init();
    }

    void Init()
    {
        // resource 추가
        // 위치를 옮기는게 나은가?
        resource = Managers.Resource;
        bullet = resource.LoadFromResources<Object>("Bullet") as GameObject;
        
        bullet.transform.rotation = gameCamera.transform.rotation;

        gameInput.OnBulletChange_Left += ChangeBullet_Left;
        gameInput.OnBulletChange_Right += ChangeBullet_Right;
    }

    void Update()
    {
        transform.position = GetScreenToWorldPosition();
        if (gameInput.GetIsAttack())
        {
            GameInput_Fire();
        }
    }
    

    void GameInput_Fire()
    {
        flashParticle.Play();

        Vector3 dir = gameCamera.transform.forward;
        
        Debug.DrawRay(transform.position, dir * 100f, Color.red, 1.0f);

        // 추후 다른 형태로 변경
        GameObject obj = Instantiate(bullet, transform.position, gameCamera.transform.rotation);

        GunshipBullet gBullet = obj.GetComponent<GunshipBullet>();

        gBullet.InitBulletColor(BulletType);
        gBullet.ShotBullet(dir, bulletSpeed);
    }

    void ChangeBullet_Left(object sender, System.EventArgs e)
    {
        if(BulletType <= EColorType.None)
        {
            BulletType = EColorType.Yellow;
            return;
        }
        BulletType -= 1;
    }

    // Enum 순서 바꾸기 
    void ChangeBullet_Right(object sender, System.EventArgs e)
    {
        if(BulletType >= EColorType.Yellow)
        {
            BulletType = EColorType.White;
            return;
        }
        BulletType += 1;
    }


    // 좌하단 스크린 포지션을 월드 포지션으로 변경
    Vector3 GetScreenToWorldPosition()
    {
        bottomLeftScreen = new Vector3(0, 0, gameCamera.nearClipPlane);
        bottomLeftWorld = gameCamera.ScreenToWorldPoint(bottomLeftScreen);

        return bottomLeftWorld;
    }
}
