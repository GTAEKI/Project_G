using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public event Action<Transform> OnSelectHeroRespawnPoint;

    public void SelectHeroRespawnPoint(Transform transform) 
    {
        OnSelectHeroRespawnPoint?.Invoke(transform);
    }


    public event Action OnGameWin;
    public void Win() 
    {
        Managers.UI.Get<UI_WinResult>().gameObject.SetActive(true);
        OnGameWin?.Invoke();
    }


    public event Action OnGameLose;
    public void Lose() 
    {
        Managers.UI.Get<UI_LoseResult>().gameObject.SetActive(true);
        OnGameLose?.Invoke();
    }

}
