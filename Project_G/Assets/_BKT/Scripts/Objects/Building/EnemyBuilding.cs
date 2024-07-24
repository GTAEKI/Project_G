using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBuilding : Building
{
    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BuildingType = Define.EBuildingType.EnemyBuilding;

        return true;
    }

    public void CreateEnemy() 
    {
        Enemy enemy = Managers.Obj.Spawn<Enemy>(transform.position);
        Managers.Map.MoveTo(enemy, Managers.Map.World2Cell(enemy.transform.position), true);
    }
}
