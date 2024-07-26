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
        Hp = 100f;
        Speed = 10f;
        Power = 10;
    }
}
