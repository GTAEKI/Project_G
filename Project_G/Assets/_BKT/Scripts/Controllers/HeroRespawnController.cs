using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HeroRespawnController : InitBase,IController
{
    private Ray ray;
    private RaycastHit hit;

    public GameObject SelectedRespawnPoint { get; private set; }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        RegisterController();

        return true;
    }

    private void FixedUpdate()
    {

        if (Input.GetMouseButtonDown(0)) 
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            int layerMask = 1 << LayerMask.NameToLayer(Define.RespawnPoint);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask) == true)
            {
                SelectedRespawnPoint = hit.collider.gameObject;
                Debug.DrawLine(transform.position, hit.point, Color.red,0.2f);
                Managers.Controller.Get<CinemachineController>().ChangeCamera(Define.EVirtualCamera.GameViewCamera);
            }
            else 
            {
                Debug.Log("타겟이 아닙니다.");
            }
        }
    }

    public void RegisterController()
    {
        Managers.Controller.Register(this);
    }
}
