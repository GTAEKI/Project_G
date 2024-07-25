using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBuilding : Building
{
    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BuildingType = Define.EBuildingType.TargetBuilding;

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
