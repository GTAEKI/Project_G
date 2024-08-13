using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Red : Enemy
{
    [SerializeField]
    private  float _R_HP = 80f;
    [SerializeField]
    private  float _R_Speed = 20f;
    [SerializeField]
    private  float _R_Power = 10f;

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        ColorType = Define.EColorType.Red;

        return true;
    }

    public override void SetInfo()
    {
        base.SetInfo();
        float multiple = Managers.Round.GetCurrentRoundDifficulty().enemyDifficultyMultiple;
        SetHp(_R_HP * multiple);
        Speed = _R_Speed * multiple;
        Power = _R_Power * multiple;
    }
}
