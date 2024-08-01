using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class TargetBuilding : Building
{
    private UI_MissionProgressBar _progressBar;
    private UI_WorldSpace_Hp UI_Building_Hp { get; set; }
    //private bool _isDestroy = false;
    public float Hp { get; private set; } = 100f;
    private float _missionProgress = 0f;

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BuildingType = Define.EBuildingType.TargetBuilding;
        UI_Building_Hp.SetMaxHp(Hp);

        return true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Hero입장");
            StartCoroutine(FillMissionProgress());
        }
    }

    IEnumerator FillMissionProgress()
    {
        while (_missionProgress <= 100) 
        {
            _missionProgress += Time.deltaTime;
            Managers.UI.Get<UI_MissionProgressBar>().ReflectValue(_missionProgress);
            yield return null;
        }
        
        Managers.Game.Win();
    }

    public void Attacked(float enemyPower)
    {
        Hp -= enemyPower;
        UI_Building_Hp.ReflectUI(Hp);

        if (Hp <= 0)
        {
            Managers.Game.Lose();
        }
    }
}
