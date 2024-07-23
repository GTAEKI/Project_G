using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extension
{
    public static T GetOrAddComponent<T>(this GameObject go) where T : Component 
    {
        T component = go.GetComponent<T>();
        if(component == null) 
        {
            component = go.AddComponent<T>();
        }

        return component;
    }

    public static bool IsValid(this GameObject go) 
    {
        return go != null && go.activeSelf;
    }
}
