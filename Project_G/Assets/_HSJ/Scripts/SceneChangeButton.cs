using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangeButton : MonoBehaviour
{
    public void OnClickButton()
    {
        Util.LoadScene(Define.EScene.BattleScene);
    }
}
