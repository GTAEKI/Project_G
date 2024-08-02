using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BattleScene : InitBase
{
    [SerializeField]
    private int _maxEnemy = 5;

    Coroutine coEnemyRespawn;

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        Managers.Map.LoadMap("BattleMap");

        #region Register Buildings
        GameObject[] EnemyRespawnPoints = GameObject.FindGameObjectsWithTag(Define.EnemyRespawn);
        GameObject[] TargetBuildings = GameObject.FindGameObjectsWithTag(Define.TargetBuilding);

        foreach (var target in TargetBuildings)
        {
            TargetBuilding targetBuilding = target.GetOrAddComponent<TargetBuilding>();
            Managers.Obj.Register(targetBuilding);
        }

        foreach (var enemyPoint in EnemyRespawnPoints)
        {
            EnemyBuilding enemyBuilding = enemyPoint.GetOrAddComponent<EnemyBuilding>();
            Managers.Obj.Register(enemyBuilding);
        }
        #endregion

        #region Register UI
        //Managers.UI.Create<UI_WinResult>();
        //Managers.UI.Create<UI_LoseResult>();
        #endregion

        Managers.Game.OnSelectHeroRespawnPoint -= StartGame;
        Managers.Game.OnSelectHeroRespawnPoint += StartGame;
        Managers.Game.OnGameResult -= EndGame;
        Managers.Game.OnGameResult += EndGame;

        return true;
    }

    public void StartGame(Transform transform) 
    {
        Hero hero = Managers.Obj.Spawn<Hero>(transform.position);
        Managers.Map.MoveTo(hero, Managers.Map.World2Cell(hero.transform.position), true);
        coEnemyRespawn = StartCoroutine(CoCreateEnemy());
        
    }

    IEnumerator CoCreateEnemy() 
    {
        while (true)
        {

            foreach (var enemyBuilding in Managers.Obj.EnemyBuildings)
            {
                // 최대 적 숫자 설정
                if (Managers.Obj.Enemies.Count >= _maxEnemy)
                    yield return new WaitUntil(() => Managers.Obj.Enemies.Count < _maxEnemy);

                int spawnChance = Random.Range(0, 10);
                float spawnTime = Random.Range(0, 3);


                if (spawnChance < 2)
                    yield return new WaitForSeconds(spawnTime);

                enemyBuilding.CreateEnemy();
                yield return new WaitForSeconds(spawnTime);
            }
        }
    }

    public void EndGame()
    {
        StopCoroutine(coEnemyRespawn);
    }

    void OnDestroy()
    {
        Managers.Game.OnSelectHeroRespawnPoint -= StartGame;
        Managers.Game.OnGameResult -= EndGame;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            Managers.Pool.CheckPool();
    }
}
