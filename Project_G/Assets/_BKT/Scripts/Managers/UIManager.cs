using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager
{
    Dictionary<string, UI_Base> UIs = new Dictionary<string, UI_Base>();


    #region TODO _ UIRoot
    //public Transform UIRoot 
    //{ 
    //    get 
    //    { 
    //        Transform rootTransform = Util.GetRootTransform("@UICanvas");
    //        GameObject root = rootTransform.gameObject;

    //        Canvas canvas = root.AddComponent<Canvas>();
    //        { 
    //            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
    //        }

    //        CanvasScaler scaler = root.AddComponent<CanvasScaler>();
    //        {
    //            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
    //            scaler.referenceResolution = new Vector2(2560, 1440);
    //            scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.Expand;
    //        }

    //        root.AddComponent<GraphicRaycaster>();

    //        return rootTransform;
    //    } 
    //} 
    #endregion

    public void Register<T>(T ui) where T : UI_Base
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

    #region TODO _ Create
    // 생성
    //public T Create<T>() where T : UI_Base
    //{
    //    string prefabName = typeof(T).Name;
    //    GameObject go = Managers.Resource.Instantiate<GameObject>($"UI/{prefabName}");
    //    go.name = prefabName;
    //    go.transform.parent = UIRoot;

    //    T ui = go.GetComponent<T>();

    //    Register(ui);

    //    return ui;
    //} 
    #endregion
}
