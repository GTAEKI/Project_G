using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hero : Creature
{
    public TargetBuilding TargetBuiding { get; private set; }
    private bool _isTakingOver = false;

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

        Speed = 4f;
        CreatureState = Define.ECreatureState.Idle;

    }

    protected override void UpdateIdle()
    {
        if (_isTakingOver == true) 
        {

            return;
        }

        TargetBuilding building = FindClosestObject(Managers.Obj.TargetBuildings) as TargetBuilding;

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
