using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_StandbyESC : UI_Base
{
    private Transform panel;
    private bool isPanelActive = false;

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        panel = transform.GetChild(0);

        return true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePanel();
        }
    }

    public void TogglePanel() 
    {
        if (isPanelActive == false)
            panel.gameObject.SetActive(true);
        else
            panel.gameObject.SetActive(false);

        isPanelActive = !isPanelActive;
    }


    protected override void Register()
    {
        Managers.UI.Register(this);
    }
}
