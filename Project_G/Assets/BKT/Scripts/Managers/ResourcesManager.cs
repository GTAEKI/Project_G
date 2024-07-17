using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class ResourceManager
{
    private Dictionary<string, UnityEngine.Object> _resources = new Dictionary<string, UnityEngine.Object>();

    // 데이터 폴더에서 읽어오기
    public T LoadFromData<T>(string key) where T : Object
    {
        return Resources.Load<T>($"Data/{key}");
    }
}
