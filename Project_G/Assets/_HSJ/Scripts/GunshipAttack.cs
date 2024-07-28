using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GunshipAttack : MonoBehaviour
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

    // 병합 후 테스트
    //private Define.EColorType bulletType;
    public enum EBULLET_TYPE
    {
        NONE, WHITE, RED, YELLOW
    }
    [SerializeField]
    EBULLET_TYPE type = EBULLET_TYPE.NONE;
    void Start()
    {
        Init();
        gameInput.OnFireAction += GameInput_Fire;
    }

    void Init()
    {
        // resource 추가
        // 위치를 옮기는게 나은가?
        resource = Managers.Resource;
        bullet = resource.LoadFromResources<Object>("Bullet") as GameObject;
        
        bullet.transform.rotation = gameCamera.transform.rotation;
        
    }

    void Update()
    {
        transform.position = GetScreenToWorldPosition();
    }


    void GameInput_Fire(object sender, System.EventArgs e)
    {
        flashParticle.Play();

        Vector3 dir = gameCamera.transform.forward;
        
        Debug.DrawRay(transform.position, dir * 100f, Color.red, 1.0f);

        // 추후 다른 형태로 변경
        GameObject obj = Instantiate(bullet, transform.position, gameCamera.transform.rotation);

        GunshipBullet gBullet = obj.GetComponent<GunshipBullet>();

        gBullet.InitBulletColor(SwitchBulletType());
        gBullet.ShotBullet(dir, bulletSpeed);
    }

    string SwitchBulletType()
    {
        string bulletType = default;
        switch(type)
        {
            case EBULLET_TYPE.WHITE:
                bulletType = "White";
                break;
            case EBULLET_TYPE.RED:
                bulletType = "Red";
                break;
            case EBULLET_TYPE.YELLOW:
                bulletType = "Yellow";
                break;
        }
        return bulletType;

    }

    // 좌하단 스크린 포지션을 월드 포지션으로 변경
    Vector3 GetScreenToWorldPosition()
    {
        bottomLeftScreen = new Vector3(0, 0, gameCamera.nearClipPlane);
        bottomLeftWorld = gameCamera.ScreenToWorldPoint(bottomLeftScreen);

        return bottomLeftWorld;
    }
}
