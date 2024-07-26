using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    Dictionary<string, UI_Base> UIs = new Dictionary<string, UI_Base>();

    public void Register<T>(T ui) where T:UI_Base
    {
        string key = typeof(T).Name;
        UIs.Add(key, ui);
    }

    public T Get<T>() where T : UI_Base 
    {
        return UIs[typeof(T).Name] as T;
    }

    public void Remove<T>() 
    {
        UIs.Remove(typeof(T).Name);
    }
}
