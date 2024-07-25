using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineController :InitBase, IController
{
    public GameObject TopViewCamera { get; private set; }
    public GameObject GameViewCamera { get; private set; }

    public override bool Init()
    {
        if(base.Init()==false)
            return false;

        RegisterController();

        TopViewCamera = GameObject.Find(Define.EVirtualCamera.TopViewCamera.ToString());
        GameViewCamera = GameObject.Find(Define.EVirtualCamera.GameViewCamera.ToString());
        GameViewCamera.SetActive(false);

        return true;
    }

    public void ChangeCamera(Define.EVirtualCamera changeCam)
    {
        switch (changeCam)
        {
            case Define.EVirtualCamera.TopViewCamera:
                TopViewCamera.SetActive(true);
                GameViewCamera.SetActive(false);
                break;
            case Define.EVirtualCamera.GameViewCamera:
                GameViewCamera.SetActive(true);
                TopViewCamera.SetActive(false);
                break;
        }
    }

    public void RegisterController()
    {
        Managers.Controller.Register(this);
    }
}
