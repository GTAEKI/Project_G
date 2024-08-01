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
        Hp = 500f;
        Speed = 3f;
        Power = 5;
        base.SetInfo();
    }
}
