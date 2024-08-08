using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Red : Enemy
{
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
        float multiple = Managers.Round.GetCurrentRound().enemyDifficultyMultiple;
        SetHp(100f * multiple);
        Speed = 10f * multiple;
        Power = 10 * multiple;

    }
}
