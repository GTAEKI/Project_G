using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClearScene : InitBase
{
    public override bool Init()
    {
        if(base.Init() == false)
            return false;

        Managers.Sound.Play(Define.ESound.Bgm, "GameClearScene");

        return true;
    }
}
