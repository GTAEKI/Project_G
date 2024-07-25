using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public void SelectHeroRespawnPoint(Transform transform) 
    {
        OnSelectHeroRespawnPoint?.Invoke(transform);
    }

    public event Action<Transform> OnSelectHeroRespawnPoint;
}
