using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : BaseObject
{
    public float Speed { get; protected set; } = 1.0f;
    public Define.ECreatureType CreatureType { get; protected set; } = Define.ECreatureType.None;
    protected Define.ECreatureState _creatureState = Define.ECreatureState.None;
    public Define.ECreatureState CreatureState 
    {
        get { return _creatureState; }
        set 
        {
            _creatureState = value; 
            UpdateCreatureState();
        }
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        ObjectType = Define.EObjectType.Creature;

        return true;
    }

    private void UpdateCreatureState() 
    {
        switch (_creatureState) 
        {
            case Define.ECreatureState.Idle:
                break;
            case Define.ECreatureState.Move:
                break;
            case Define.ECreatureState.Die:
                break;
        }
    }
}
