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
        base.UpdateIdle();

        TargetBuiding = FindClosestObject(Managers.Obj.Buildings) as Building;

        if (TargetBuiding != null) 
        {
            CreatureState = Define.ECreatureState.Move;
        }
    }

    protected override void UpdateMove()
    {
        base.UpdateMove();
        Debug.Log($"{this.name} UpdateMove");
        if (TargetBuiding == null)
        {
            CreatureState = Define.ECreatureState.Idle;
        }
        else 
        {
            FindPathAndMoveToCellPos(TargetBuiding.transform.position);
        }
    }
}
