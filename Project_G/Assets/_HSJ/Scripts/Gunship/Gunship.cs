using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

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
            GameInput = Util.GetRootObject("GameInput").GetComponent<GameInput>();
        }
        if(MainCamera == null)
        {
            MainCamera = Camera.main;
        }
    }


    
}
