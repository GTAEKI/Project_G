using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoundManager
{
    public class RoundSetting
    {
        public RoundSetting(int _maxEnemyCount, float _hpMultiple, float _powerMultiple, int scrapCount)
        {
            maxEnemyCount = _maxEnemyCount;
            enemyHpMultiple = _hpMultiple;
            enemyPowerMultiple = _powerMultiple;
            this.scrapCount = scrapCount;
        }

        public int maxEnemyCount;
        public float enemyHpMultiple;
        public float enemyPowerMultiple;
        public int scrapCount;
    }

    private List<RoundSetting> rounds = new List<RoundSetting>();
    public int CurrentRound { get; private set; } = 0;
    public bool IsAllRoundClear { get; private set; } = false;

    public RoundManager() 
    {
        rounds.Add(new RoundSetting(20, 1f, 1f, 500));
        rounds.Add(new RoundSetting(20, 1.5f, 1.1f, 700));
        rounds.Add(new RoundSetting(25, 2f, 1.2f,800));
        rounds.Add(new RoundSetting(30, 3f, 1.3f,1000));
        rounds.Add(new RoundSetting(40, 4f, 1.4f, 1200));
    }

    public RoundSetting GetCurrentRoundSetting() 
    {
        return rounds[CurrentRound];
    }

    public void NextRound() 
    {
        if (CurrentRound < rounds.Count - 1) 
        {
            CurrentRound++;
        }
    }

    public bool HasNextRound() 
    {
        if (CurrentRound == rounds.Count-1)
        {
            return false;
        }

        return true;
    }

    public void RoundAllClear() 
    {
        IsAllRoundClear = true;
    }

    public void ResetRound() 
    {
        CurrentRound = 0;
        IsAllRoundClear = false;
    }
    
}
