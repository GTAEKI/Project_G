using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;

public class ResourceManager
{
    // Resources 폴더에서 읽어오기
    public T LoadFromResources<T>(string key) where T : Object
    {
        return Resources.Load<T>($"{key}");
    }

    public T Instantiate<T>(string key) where T : Object 
    {
        T obj = LoadFromResources<T>(key);
        return Object.Instantiate(obj);
    }

    public void Destroy(GameObject go)
    {
        if (go == null)
            return;

        Object.Destroy(go);
    }
}
