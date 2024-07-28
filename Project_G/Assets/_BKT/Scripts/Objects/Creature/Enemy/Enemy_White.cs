using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_White : Enemy
{
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
        Hp = 100f;
        Speed = 5f;
        Power = 5;
    }
}
