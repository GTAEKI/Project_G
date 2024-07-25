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

        return true;
    }

}
