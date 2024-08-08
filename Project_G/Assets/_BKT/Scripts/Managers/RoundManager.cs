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
    private int currentRound = 0;

    public RoundManager() 
    {
        GameDifficulty round1 = new GameDifficulty(10, 1f);
        GameDifficulty round2 = new GameDifficulty(15, 1.5f);
        GameDifficulty round3 = new GameDifficulty(20, 2f);
        GameDifficulty round4 = new GameDifficulty(25, 2.5f);

        rounds.Add(round1);
        rounds.Add(round2);
        rounds.Add(round3);
        rounds.Add(round4);
    }

    public GameDifficulty GetCurrentRound() 
    {
        Debug.Log($"CurrentRound is {currentRound}");
        return rounds[currentRound];
    }

    public void NextRound() 
    {
        currentRound++;
    }
    
}
