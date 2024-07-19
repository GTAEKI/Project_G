using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScene : InitBase
{
    public GameObject HeroRespawn { get; private set; }
    public GameObject EnemyRespawn { get; private set; }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        Managers.Map.LoadMap("TestMap");

        HeroRespawn = GameObject.Find(Define.HeroRespawn);
        EnemyRespawn = GameObject.Find(Define.EnemyRespawn);

        Hero hero = Managers.Obj.Spawn<Hero>(HeroRespawn.transform.position);
        if (Managers.Map.CanGo(hero.transform.position) == true)
        {
            hero.SetCellPos(Vector3Int.FloorToInt(hero.transform.position), true);
        }
        else 
        {
            Debug.Log("Fail");
        }
            

        Enemy enemy = Managers.Obj.Spawn<Enemy>(EnemyRespawn.transform.position);
        if (Managers.Map.CanGo(enemy.transform.position) == true) 
        {
            enemy.SetCellPos(Vector3Int.FloorToInt(enemy.transform.position), true);
        }


        return true;
    }
}
