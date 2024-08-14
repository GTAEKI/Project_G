using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager
{
    public class GameDifficulty
    {
        public GameDifficulty(int _maxEnemyCount, float _enemyDifficultyMultiple) 
        {
            maxEnemyCount = _maxEnemyCount;
            enemyDifficultyMultiple = _enemyDifficultyMultiple;
        }

        public int maxEnemyCount;
        public float enemyDifficultyMultiple;
    }

    private List<GameDifficulty> rounds = new List<GameDifficulty>();
    public int CurrentRound { get; private set; } = 0;
    //public bool IsLastRound { get; private set; } = false;

    public RoundManager() 
    {
        rounds.Add(new GameDifficulty(40,1f));
        rounds.Add(new GameDifficulty(60, 1.1f));
        rounds.Add(new GameDifficulty(80, 1.2f));
        rounds.Add(new GameDifficulty(120, 1.3f));
    }

    public GameDifficulty GetCurrentRoundDifficulty() 
    {
        Debug.Log($"CurrentRound is {CurrentRound}");
        return rounds[CurrentRound];
    }

    public event Action OnLastRound;
    public void NextRound() 
    {
        if (CurrentRound < rounds.Count - 1) 
        {
            CurrentRound++;       
        }
        else if (CurrentRound == rounds.Count - 1) 
        {
            OnLastRound?.Invoke();
        }
    }

    public void ResetRound() 
    {
        CurrentRound = 0;
    }
    
}
