using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScene : InitBase
{
    //public GameObject[] HeroRespawnPoints { get; private set; }
    public GameObject[] EnemyRespawnPoints { get; private set; }
    public GameObject[] TargetBuildings { get; private set; }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        Managers.Map.LoadMap("TutorialMap");

        //HeroRespawnPoints = GameObject.FindGameObjectsWithTag(Define.HeroRespawn);
        EnemyRespawnPoints = GameObject.FindGameObjectsWithTag(Define.EnemyRespawn);
        TargetBuildings = GameObject.FindGameObjectsWithTag(Define.TargetBuilding);

        Building targetBuilding = TargetBuildings[0].GetOrAddComponent<Building>();
        Managers.Obj.Register(targetBuilding);

        Managers.Game.OnSelectHeroRespawnPoint += StartGame;

        return true;
    }

    public void StartGame(Transform transform) 
    {
        Hero hero = Managers.Obj.Spawn<Hero>(transform.position);
        Managers.Map.MoveTo(hero, Managers.Map.World2Cell(hero.transform.position), true);

        foreach (var enemyRespawn in EnemyRespawnPoints)
        {
            Enemy enemy = Managers.Obj.Spawn<Enemy>(enemyRespawn.transform.position);
            Managers.Map.MoveTo(enemy, Managers.Map.World2Cell(enemy.transform.position), true);
        }
    }
}
