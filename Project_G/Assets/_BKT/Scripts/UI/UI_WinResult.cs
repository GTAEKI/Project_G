using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_WinResult : UI_Base
{
    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        Register();
        gameObject.SetActive(false);
        Debug.Log(this);
        return true;
    }

    protected override void Register()
    {
        Managers.UI.Register(this);
    }

    private void OnDestroy()
    {
        Managers.UI.Remove<UI_WinResult>();
    }
}
