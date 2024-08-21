using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_White : Enemy
{
    [SerializeField]
    private float _W_HP = 100f;
    [SerializeField]
    private float _W_Speed = 10f;
    [SerializeField]
    private float _W_Power = 10f;

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        ColorType = Define.EColorType.White;

        return true;
    }

    public override void SetInfo()
    {
        base.SetInfo();
        float multiple = Managers.Round.GetCurrentRoundSetting().enemyDifficultyMultiple;
        SetHp(_W_HP * multiple);
        Speed = _W_Speed * multiple;
        Power = _W_Power * multiple;
    }
}
