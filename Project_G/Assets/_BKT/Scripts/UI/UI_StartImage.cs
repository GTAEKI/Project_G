using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_StartImage : InitBase
{
    private UI_EventHandler _EventHandler;

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        _EventHandler = this.GetOrAddComponent<UI_EventHandler>();
        _EventHandler.OnClickHandler += OnPointerClick;

        return true;
    }

    public void OnPointerClick(PointerEventData eventData) 
    {
        Util.LoadScene(Define.EScene.TutorialScene);
    }
}
