using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Yellow : Enemy
{
    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        ColorType = Define.EColorType.Yellow;

        return true;
    }

    public override void SetInfo()
    {
        base.SetInfo();
        float multiple = Managers.Round.GetCurrentRound().enemyDifficultyMultiple;
        SetHp(500f * multiple);
        Speed = 3f * multiple;
        Power = 5 * multiple;
    }
}
