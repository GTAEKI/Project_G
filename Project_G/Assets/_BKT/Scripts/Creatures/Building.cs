using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : BaseObject
{
    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        ObjectType = Define.EObjectType.Building;

        return true;
    }
}
