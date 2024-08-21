using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoundManager
{
    public class RoundSetting
    {
        public RoundSetting(int _maxEnemyCount, float _enemyDifficultyMultiple, int scrapCount)
        {
            maxEnemyCount = _maxEnemyCount;
            enemyDifficultyMultiple = _enemyDifficultyMultiple;
            this.scrapCount = scrapCount;
        }

        public int maxEnemyCount;
        public float enemyDifficultyMultiple;
        public int scrapCount;
    }

    private List<RoundSetting> rounds = new List<RoundSetting>();
    public int CurrentRound { get; private set; } = 0;
    public bool IsAllRoundClear { get; private set; } = false;

    public RoundManager() 
    {
        rounds.Add(new RoundSetting(20, 1f, 500));
        rounds.Add(new RoundSetting(30, 1.1f, 700));
        rounds.Add(new RoundSetting(40, 1.2f, 1000));
        rounds.Add(new RoundSetting(45, 1.3f, 1500));
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
    }
    
}
