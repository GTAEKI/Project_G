using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using static Define;

public class GunshipBarrel : MonoBehaviour
{

    private Gunship gunship;
    private Camera mainCamera;
    private GameInput gameInput;
  
    private ResourceManager resource;
    private GameObject bullet;
    private Vector3 bottomLeftScreen;
    private Vector3 bottomLeftWorld;
    private Vector3 barrelOffset = new Vector3(1f,0f,0f);
    private float bulletSpeed = 100f;
    private const float bulletDelay = 0.1f;
    private bool isFire = default;

    [field: SerializeField]
    public EColorType BulletType { get; private set; }

    [SerializeField]
    private LayerMask layer;

    int count = 0;

    void Start()
    {
        Init();
    }

    void Init()
    {
        gunship = GetComponentInParent<Gunship>();

        gameInput = gunship.GameInput;
        mainCamera = gunship.MainCamera;

        //resource = Managers.Resource;
        //bullet = resource.LoadFromResources<Object>("Bullet") as GameObject;        
        //GameObject bullet = projectileManager.Dequeue();
        //bullet.transform.rotation = mainCamera.transform.rotation;

        BulletType = EColorType.White;
        InitInputEvent();
    }
    // 이벤트 등록
    void InitInputEvent()
    {
        gameInput.OnBulletChange_Left += ChangeBullet_Left;
        gameInput.OnBulletChange_Right += ChangeBullet_Right;
    }
    

    void Update()
    {
        transform.position = GetScreenToWorldPosition();

        if (Managers.Game.IsGameEnded == false && gameInput.GetIsAttack())
        {
            GameInput_Fire();

            // BKT 임시 Test
            count += 1;
            if (count >= 4)
            {
                Managers.Sound.Play(ESound.Effect, "Gun4_1");
                count = 0;
            }
        }
    }


    void GameInput_Fire()
    {
        RaycastHit hit;
       
        Vector3 targetPoint;
        if(Physics.Raycast(mainCamera.transform.position,mainCamera.transform.forward, out hit, float.MaxValue, layer))
        {
            targetPoint = hit.point;
        }
        else
        {
            return;
        }

        //GameObject bullet = 
        //    Managers.Projectile.Dequeue(
        //        transform.position,
        //        mainCamera.transform.rotation);

        //GunshipBullet gBullet = bullet.GetComponent<GunshipBullet>();

        //gBullet.InitBulletColor(BulletType);
        //gBullet.ShotBullet(dir, bulletSpeed);
        
        if(isFire) { return; }
        StartCoroutine(DelayFire(targetPoint));
    }

    IEnumerator DelayFire(Vector3 targetPoint)
    {
        float timer = 0;
        while(bulletDelay > timer)
        {
            isFire = true;
            timer += Time.deltaTime;
            yield return null;
        }

        Vector3 dir = (targetPoint - transform.position).normalized;

        GameObject bullet =
           Managers.Projectile.Dequeue(
               transform.position,
               mainCamera.transform.rotation,
               "Bullet");

        GunshipBullet gBullet = bullet.GetComponent<GunshipBullet>();

        gBullet.InitBulletColor(BulletType);
        gBullet.ShotBullet(dir, bulletSpeed);
        isFire = false;

    }

    void ChangeBullet_Left(object sender, System.EventArgs e)
    {
        if(BulletType <= EColorType.White)
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
        bottomLeftScreen = new Vector3(0, 0, mainCamera.nearClipPlane);
        bottomLeftWorld = mainCamera.ScreenToWorldPoint(bottomLeftScreen );
        bottomLeftWorld -= barrelOffset;
        
        return bottomLeftWorld;
    }
}
