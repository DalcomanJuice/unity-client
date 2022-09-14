using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    //sortOrder 관리.
    int _order = 10;

    Stack<UIPopup> _popupStack = new Stack<UIPopup>();
    UIScene _sceneUI = null;

    public GameObject Root
    {
        get {
            GameObject root = GameObject.Find("@UI_Root");
            if (root == null)
                root = new GameObject { name = "@UI_Root" };
            return root;
        }
    }

    //외부에서 팝업같은 유아이 호출할 때, 켜질건데, 기존 유아이와 나의 우선순위를 정해주세요.
    public void SetCanvas(GameObject go, bool sort = true)
    {
        Canvas canvas = Util.GetOrAddComponent<Canvas>(go);
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.overrideSorting = true; //캔버스 안에 캔버스가 있어도 내 안에 소팅오더를 같는다는 표현.

        if (sort)
        {
            canvas.sortingOrder = (_order);
            _order++;
        }
        else //popupUI 이와 관련 없다
        {
            canvas.sortingOrder = 0;
        }
            
    }

    public T ShowSceneUI<T>(string name = null) where T : UIScene
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        //이미 만들어진것을 프리팹으로 만들어서 보여준다.
        GameObject go = Managers.Resource.Instantiate($"UI/Scene/{name}");

        T sceneUI = Util.GetOrAddComponent<T>(go);

        _sceneUI = sceneUI;

        go.transform.SetParent(Root.transform);
        
        return sceneUI;
    }


    public T ShowPopupUI<T>(string name= null) where T : UIPopup
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        //이미 만들어진것을 프리팹으로 만들어서 보여준다.
        GameObject go = Managers.Resource.Instantiate($"UI/Popup/{name}");  

        T popup = Util.GetOrAddComponent<T>(go);
        _popupStack.Push(popup);

        GameObject root = GameObject.Find("@UI_Root");
        if (root == null)
            root = new GameObject { name = "@UI_Root" };

        go.transform.SetParent(root.transform);

        return popup;
    }

    public void ClosePopupUI(UIPopup popup)
    {
        if (_popupStack.Count == 0)
            return;

        if(_popupStack.Peek() != popup) //확인하고 넣은다.
        {
            Debug.Log("Close Popup Failed!");
            return;
        }

        CloseAllPopupUI();
    }

    public void ClosePopupUI()
    {
        if (_popupStack.Count == 0)
            return;

        UIPopup popup = _popupStack.Pop();
        Managers.Resource.Destroy(popup.gameObject);
        popup = null;

        _order--;
    }

    public void CloseAllPopupUI()
    {
        while (_popupStack.Count > 0)
            ClosePopupUI();
    }
}
