using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_MissionProgressBar : UI_Base
{
    private Slider _progressBar;
    public float MaxMissionValue { get; private set; } = 1f;

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        _progressBar = GetComponent<Slider>();
        SetMaxValue(MaxMissionValue);
        Register();

        return true;
    }

    public void SetMaxValue(float value) 
    {
        _progressBar.maxValue = value; 
    }

    public void ReflectValue(float value) 
    {
        _progressBar.value = value;
    }

    protected override void Register()
    {
        Managers.UI.Register(this);
    }

    private void OnDestroy()
    {
        Managers.UI.Remove<UI_MissionProgressBar>();
    }
}
