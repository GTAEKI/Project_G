using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBuilding : Building
{
    private UI_MissionProgressBar _progressBar;
    //private bool _isDestroy = false;
    public float Hp { get; private set; } = 100f;
    private float _missionProgress = 0f;

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BuildingType = Define.EBuildingType.TargetBuilding;

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
            //yield return new WaitForSeconds(0.1f);
        }
        Debug.Log("완료");
    }
}
