using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : Creature
{
    public Hero TargetHero { get; private set; }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        CreatureType = Define.ECreatureType.Enemy;

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

        TargetHero = FindClosestObject(Managers.Obj.Heroes) as Hero;

        if (TargetHero != null)
        {
            CreatureState = Define.ECreatureState.Move;
        }
    }

    protected override void UpdateMove()
    {
        base.UpdateMove();
        Debug.Log($"{this.name} UpdateMove");
        if (TargetHero == null)
        {
            CreatureState = Define.ECreatureState.Idle;
        }
        else
        {
            FindPathAndMoveToCellPos(TargetHero.transform.position);
        }
    }
}
