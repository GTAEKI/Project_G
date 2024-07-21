using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hero : Creature
{
    public Building TargetBuiding { get; private set; }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        CreatureType = Define.ECreatureType.Hero;

        return true;
    }

    public override void SetInfo()
    {
        base.SetInfo();

        CreatureState = Define.ECreatureState.Idle;

    }

    protected override void UpdateIdle()
    {
        Building building = FindClosestObject(Managers.Obj.Buildings) as Building;

        if (building != null) 
        {
            TargetBuiding = building;
            CreatureState = Define.ECreatureState.Move;
        }
    }

    protected override void UpdateMove()
    {
        base.UpdateMove();

        if (TargetBuiding == null)
        {
            CreatureState = Define.ECreatureState.Idle;
        }
        else 
        {
            Define.EFindPathResult result = FindPathAndMoveToCellPos(TargetBuiding.transform.position);
            switch (result)
            {
                case Define.EFindPathResult.Success:
                    break;
                case Define.EFindPathResult.Fail_NoPath:
                    break;
                case Define.EFindPathResult.Fail_LerpCell:
                    break;
                case Define.EFindPathResult.Fail_MoveTo:
                    break;
            }

            //Debug.Log(result);
        }
    }
}
