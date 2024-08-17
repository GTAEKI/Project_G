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

    public RoundManager() 
    {
        rounds.Add(new GameDifficulty(20, 1f));
        rounds.Add(new GameDifficulty(25, 1.1f));
        rounds.Add(new GameDifficulty(30, 1.2f));
        rounds.Add(new GameDifficulty(35, 1.3f));
    }

    public GameDifficulty GetCurrentRoundDifficulty() 
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
        if (CurrentRound == rounds.Count - 1)
        {
            return false;
        }

        return true;
    }

    public void ResetRound() 
    {
        CurrentRound = 0;
    }
    
}
