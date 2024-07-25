using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Base : InitBase
{
    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        return true;
    }
}
