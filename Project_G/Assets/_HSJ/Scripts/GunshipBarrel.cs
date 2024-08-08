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

    [field: SerializeField]
    public EColorType BulletType { get; private set; }

    [SerializeField]
    private LayerMask layer;
    void Start()
    {
        Init();
    }

    void Init()
    {
        gunship = GetComponentInParent<Gunship>();

        gameInput = gunship.GameInput;
        mainCamera = gunship.MainCamera;

        resource = Managers.Resource;
        bullet = resource.LoadFromResources<Object>("Bullet") as GameObject;        
        bullet.transform.rotation = mainCamera.transform.rotation;

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
        
        if (gameInput.GetIsAttack())
        {
            GameInput_Fire();
        }
    }


    void GameInput_Fire()
    {
        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        

        Vector3 targetPoint;
        if(Physics.Raycast(mainCamera.transform.position,mainCamera.transform.forward, out hit, float.MaxValue, layer))
        {
            targetPoint = hit.point;
            Debug.Log($"targetPoint pos {targetPoint}");
        }
        else
        {
            return;
        }

        Vector3 dir = (targetPoint - transform.position).normalized;
        Debug.Log($"dir :  {dir}");
        // 추후 다른 형태로 변경
        GameObject obj = Instantiate(bullet, transform.position, mainCamera.transform.rotation);
        //Managers.Pool.Create(obj);
        
        GunshipBullet gBullet = obj.GetComponent<GunshipBullet>();

        gBullet.InitBulletColor(BulletType);
        gBullet.ShotBullet(dir, bulletSpeed);
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
