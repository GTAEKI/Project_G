using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_MissionProgressBar : UI_Base
{
    private Slider _progressBar;

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        _progressBar = GetComponent<Slider>();
        Managers.UI.Register(this);
        Debug.Log(this.name);

        return true;
    }

    public void ReflectValue(float value) 
    {
        _progressBar.value = value;
    }
}
