using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_StartImage : UI_Base
{
    private UI_EventHandler _EventHandler;

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        _EventHandler = this.GetOrAddComponent<UI_EventHandler>();
        _EventHandler.OnClickHandler += OnPointerClick;
        Register();

        return true;
    }

    public void OnPointerClick(PointerEventData eventData) 
    {
        Util.LoadScene(Define.EScene.TutorialScene);
    }

    protected override void Register()
    {
        Managers.UI.Register(this);
    }
}
