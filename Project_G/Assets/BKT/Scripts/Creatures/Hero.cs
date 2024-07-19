using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Creature
{
    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        CreatureType = Define.ECreatureType.Hero;
        CreatureState = Define.ECreatureState.Idle;

        return true;
    }
}
