using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Restart : UI_MouseInteraction
{
    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        _EventHandler.OnClickHandler += OnPointerClick;
        return true;
    }

    protected override void OnPointerClick(PointerEventData eventData)
    {
        Util.LoadScene(Define.EScene.BattleScene);
    }

    protected override void Register()
    {
        Managers.UI.Register(this);
    }

    private void OnDestroy()
    {
        Managers.UI.Remove<UI_Restart>();
    }
}
