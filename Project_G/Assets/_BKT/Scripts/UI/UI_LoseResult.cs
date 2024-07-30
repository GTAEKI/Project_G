using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_LoseResult : UI_Base
{
    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        Register();
        gameObject.SetActive(false);
        return true;
    }

    protected override void Register()
    {
        Managers.UI.Register(this);
    }
}
