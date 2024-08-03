using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gunship : MonoBehaviour
{

    [field:SerializeField]
    public GameInput GameInput { get; private set; }
    [field:SerializeField]
    public Camera MainCamera { get; private set; }
    void Awake()
    {
        Init();
    }

    void Init()
    {
        if (GameInput == null)
        {
            GameInput = GetRootObject("GameInput").GetComponent<GameInput>();
        }
        if(MainCamera == null)
        {
            MainCamera = Camera.main;
        }
    }

    // Static 으로 갈 가능성?
     GameObject GetRootObject (string objectName)
    {
        Scene scene = SceneManager.GetActiveScene();
        GameObject[] rootObjects = scene.GetRootGameObjects();

        foreach(GameObject go in rootObjects)
        {
            Debug.Log("gameObject name" + go.name);
            if(go.name.Equals(objectName))
            {
                return go;
            }
            else
            {
                Debug.LogError("Can't find "+ objectName + "rootObject");
            }
        }
        // null 을 반환하면 터지니까.. 어떻게 해야 할까?
        return null;
    }
    
}
