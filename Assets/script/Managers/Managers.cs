using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    private static Managers s_Instance; 
    public static Managers Instance { get { Init(); return s_Instance; } }

    private InputManager input = new InputManager();
    private ResourceManager _resource = new ResourceManager();
    private UIManager _ui = new UIManager();

    public static InputManager Input { get { return Instance.input; } }
    public static ResourceManager Resource { get { return Instance._resource; } }
    public static UIManager UI { get { return Instance._ui; } }

    void Start()
    {
        Init();
    }

    void Update()
    {
        input.onUpdate();
    }

    static void Init()
    {
        if (null == s_Instance)
        {
            GameObject gameObject = GameObject.Find("@Managers");
            if (null == gameObject)
            {
                gameObject = new GameObject { name = "@Managers" }; //gameObject 생성
                gameObject.AddComponent<Managers>();                //gmaeObject에 컴포넌트 붙이기.
            }

            DontDestroyOnLoad(gameObject);                          //삭제되지 않게 바뀐다.
            s_Instance = gameObject.GetComponent<Managers>();
        }
    }
}