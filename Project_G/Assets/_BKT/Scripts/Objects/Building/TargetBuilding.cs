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
}
