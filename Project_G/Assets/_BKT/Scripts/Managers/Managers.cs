using System.Collections;
using System.Collections.Generic;
using System.Resources;
using System.Runtime.Serialization;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Managers : MonoBehaviour
{
    public static bool Initialized { get; set; } = false;

    private static Managers s_instance;
    private static Managers Instance { get { Init(); return s_instance; } }

    private ResourceManager _resource = new ResourceManager();
    private GameManager _game = new GameManager();
    private ObjectManager _obj = new ObjectManager();
    private MapManager _map = new MapManager();
    private ControllerManager _controller = new ControllerManager();
    private UIManager _ui = new UIManager();
    // HSJ_ 240802
    // 자원 매니저 추가
    private ScrapManager _scrap = new ScrapManager();

    public static ResourceManager Resource { get { return Instance?._resource; } }
    public static GameManager Game { get { return Instance?._game; } }
    public static ObjectManager Obj { get { return Instance?._obj; } }
    public static MapManager Map { get { return Instance?._map; } }
    public static ControllerManager Controller { get { return Instance?._controller; } }
    public static UIManager UI { get { return Instance?._ui; } }
    public static ScrapManager Scrap { get { return Instance?._scrap; } }

    public static void Init()
    {
        if (s_instance == null && Initialized == false)
        {
            Initialized = true;

            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }

            DontDestroyOnLoad(go);

            s_instance = go.GetComponent<Managers>();
        }
    }
}
