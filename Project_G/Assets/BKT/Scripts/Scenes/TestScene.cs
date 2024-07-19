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

        Managers.Obj.Spawn<Hero>(HeroRespawn.transform.position);
        Managers.Obj.Spawn<Enemy>(EnemyRespawn.transform.position);

        return true;
    }
}
