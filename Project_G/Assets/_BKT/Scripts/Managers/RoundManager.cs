using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager
{
    public class GameSet 
    {
        public GameSet(int _maxEnemyCount, float _enemyDifficultyMultiple) 
        {
            maxEnemyCount = _maxEnemyCount;
            enemyDifficultyMultiple = _enemyDifficultyMultiple;
        }

        public int maxEnemyCount;
        public float enemyDifficultyMultiple;
    }

    private List<GameSet> rounds = new List<GameSet>();
    private int currentRound = 0;

    public RoundManager() 
    {
        GameSet round1 = new GameSet(10, 1f);
        GameSet round2 = new GameSet(15, 1.5f);
        GameSet round3 = new GameSet(20, 2f);

        rounds.Add(round1);
        rounds.Add(round2);
        rounds.Add(round3);
    }

    public void Init() 
    {
        Managers.Game.OnGameWin -= NextRound;
        Managers.Game.OnGameWin += NextRound;
    }

    public GameSet GetCurrentRound() 
    {
        Debug.Log($"CurrentRound is {currentRound}");
        return rounds[currentRound];
    }

    private void NextRound() 
    {
        currentRound++;
    }
    
}
