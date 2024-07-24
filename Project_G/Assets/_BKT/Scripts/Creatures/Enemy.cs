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

        Speed = 6f;
        CreatureState = Define.ECreatureState.Idle;
    }

    protected override void UpdateIdle()
    {
        Hero hero = FindClosestObject(Managers.Obj.Heroes) as Hero;

        if (hero != null)
        {
            TargetHero = hero;
            CreatureState = Define.ECreatureState.Move;
        }
    }

    protected override void UpdateMove()
    {
        base.UpdateMove();

        if (TargetHero == null)
        {
            CreatureState = Define.ECreatureState.Idle;
        }
        else
        {
            Define.EFindPathResult result = FindPathAndMoveToCellPos(TargetHero.transform.position);
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
