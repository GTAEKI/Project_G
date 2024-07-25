using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBuilding : Building
{
    private UI_MissionProgressBar _progressBar;

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BuildingType = Define.EBuildingType.TargetBuilding;
        _progressBar = GameObject.FindObjectOfType<UI_MissionProgressBar>();

        return true;
    }

    private void OnTrigger(Collider other)
    {
        if (other.tag == "Player") 
        {
            Debug.Log("플레이어");
        }
    }

    private void Update()
    {

    }
}
