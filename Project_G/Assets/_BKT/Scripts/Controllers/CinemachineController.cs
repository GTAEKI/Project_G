using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineController :InitBase, IController
{
    private Dictionary<string, GameObject> virtualCams= new Dictionary<string,GameObject>();

    public override bool Init()
    {
        if(base.Init()==false)
            return false;

        RegisterController();

        GameObject StartViewCamera = GameObject.Find(Define.EVirtualCamera.StartViewCamera.ToString());
        virtualCams.Add(StartViewCamera.name, StartViewCamera);
        StartViewCamera.SetActive(true);

        GameObject TopViewCamera = GameObject.Find(Define.EVirtualCamera.TopViewCamera.ToString());
        virtualCams.Add(TopViewCamera.name, TopViewCamera);
        TopViewCamera.SetActive(false);

        GameObject GameViewCamera = GameObject.Find(Define.EVirtualCamera.GameViewCamera.ToString());
        virtualCams.Add(GameViewCamera.name, GameViewCamera);
        GameViewCamera.SetActive(false);
        
        StartCoroutine(SwitchToTopViewCamera());

        return true;
    }

    private IEnumerator SwitchToTopViewCamera()
    {
        yield return new WaitForSeconds(0.3f);
        ChangeCamera(Define.EVirtualCamera.TopViewCamera);
        float delayTime = Camera.main.GetComponent<CinemachineBrain>().m_DefaultBlend.m_Time;
        yield return new WaitForSeconds(delayTime);
        Managers.Game.GameStart();
    }

    public void ChangeCamera(Define.EVirtualCamera changeCam)
    {
        string name = changeCam.ToString();
        foreach (var cam in virtualCams)
        {
            if (cam.Key.Equals(name)) 
            {
                cam.Value.SetActive(true);
                continue;
            }

            cam.Value.SetActive(false);
        }
    }

    public void RegisterController()
    {
        Managers.Controller.Register(this);
    }
}
