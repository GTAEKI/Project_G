using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Define;

public class Enemy : Creature
{
    public Hero TargetHero { get; private set; }
    public int Power { get; protected set; }
    public Define.EColorType ColorType { get; protected set; }
    private UI_WorldSpace_Hp UI_EnemyHp { get; set; }

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
        UI_EnemyHp = GetComponentInChildren<UI_WorldSpace_Hp>();
        UI_EnemyHp.SetMaxHp(Hp);
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
        Hero hero = FindRangeObject(2f, Managers.Obj.Heroes) as Hero;
        if (hero != null)
        {
            animator.SetTrigger("Attack");
            return;
        }

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

    protected override void UpdateAnimation()
    {
        switch (CreatureState)
        {
            case Define.ECreatureState.Idle:
                animator.SetBool("Move", false);
                break;
            case Define.ECreatureState.Move:
                animator.SetBool("Move", true);
                break;
            case Define.ECreatureState.Die:
                animator.SetBool("Die", true);
                break;
        }
    }

    public void CalDamage(float damage, Define.EColorType colorType) 
    {
        if (ColorType == colorType)
            damage *= 2;

        Hp -= damage;
        UI_EnemyHp.ReflectUI(Hp);

        if(Hp <= 0)
        {
            CreatureState = ECreatureState.Die;
        }

    }

    public void HitHero() 
    {
        TargetHero.Attacked(Power);
    }
}
