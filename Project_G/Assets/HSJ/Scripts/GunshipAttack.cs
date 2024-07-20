using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunshipAttack : MonoBehaviour
{
    [SerializeField]
    private Camera gameCamera;
    [SerializeField]
    private GameObject sphere;
    [SerializeField]
    private GameInput gameInput;

    private Vector3 bottomLeftScreen;
    private Vector3 bottomLeftWorld;

    private float bulletSpeed = 25f;

    void Start()
    {
        gameInput.OnFireAction += GameInput_Fire;
    }

    void Update()
    {
        transform.position = GetScreenToWorldPosition();
    }

    void GameInput_Fire(object sender, System.EventArgs e)
    {
        Vector3 dir = gameCamera.transform.forward;
        
        Debug.DrawRay(transform.position, dir * 100f, Color.red, 1.0f);

        // 추후 다른 형태로 변경
        GameObject obj = Instantiate(sphere, this.transform.position, Quaternion.identity);
        obj.GetComponent<Rigidbody>().AddForce(dir * bulletSpeed, ForceMode.VelocityChange);
    }

 

    // 좌하단 스크린 포지션을 월드 포지션으로 변경
    Vector3 GetScreenToWorldPosition()
    {
        bottomLeftScreen = new Vector3(0, 0, gameCamera.nearClipPlane);
        bottomLeftWorld = gameCamera.ScreenToWorldPoint(bottomLeftScreen);

        return bottomLeftWorld;
    }
}
