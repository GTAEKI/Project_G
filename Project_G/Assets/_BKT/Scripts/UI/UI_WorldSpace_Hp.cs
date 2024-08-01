using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_WorldSpace_Hp : InitBase
{
    private Camera _mainCamera;
    private Slider _slider;

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        _mainCamera = Camera.main;
        _slider = GetComponentInChildren<Slider>();

        return true;
    }

    void LateUpdate()
    {
        if (_mainCamera != null)
            transform.LookAt(transform.position + _mainCamera.transform.rotation * Vector3.forward, _mainCamera.transform.rotation * Vector3.up);
    }

    public void SetMaxHp(float maxHp)
    {
        _slider.maxValue = maxHp;
        _slider.value = maxHp;
    }

    public void ReflectUI(float hp)
    {
        Debug.Log($"HP = {hp}");
        _slider.value = hp;
    }
}
