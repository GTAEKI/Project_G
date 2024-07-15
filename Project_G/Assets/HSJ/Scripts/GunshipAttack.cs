using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunshipAttack : MonoBehaviour
{
    [SerializeField]
    private Camera gameCamera;
    [SerializeField]
    private GameObject sphere;
    private Vector3 bottomLeftScreen;
    private Vector3 bottomLeftWorld;
    [SerializeField]
    private GameInput gameInput;

    void Start()
    {
        gameInput.OnFireAction += GameInput_Fire;
    }

    void Update()
    {
        this.transform.position = GetScreenToWorldPosition();
    }

    void GameInput_Fire(object sender, System.EventArgs e)
    {
        Vector3 mousePos = gameCamera.ScreenToWorldPoint(gameInput.GetMousePosition());
        mousePos = new Vector3(gameCamera.ScreenToWorldPoint(gameInput.GetMousePosition()).x, 0f, gameCamera.ScreenToWorldPoint(gameInput.GetMousePosition()).z);
        Vector3 dir = mousePos - transform.position;
        dir = dir.normalized;

        Debug.DrawRay(transform.position, dir * 100f, Color.red, 1.0f);

        GameObject obj = Instantiate(sphere, this.transform.position, Quaternion.identity);
        obj.GetComponent<Rigidbody>().AddForce(dir * 15f, ForceMode.Impulse);
    }

    // 좌하단 스크린 포지션을 월드 포지션으로 변경
    Vector3 GetScreenToWorldPosition()
    {
        bottomLeftScreen = new Vector3(0, 0, gameCamera.nearClipPlane);
        bottomLeftWorld = gameCamera.ScreenToWorldPoint(bottomLeftScreen);

        return bottomLeftWorld;
    }
}
