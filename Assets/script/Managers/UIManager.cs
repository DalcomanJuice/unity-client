using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    //sortOrder ����.
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

    //�ܺο��� �˾����� ������ ȣ���� ��, �����ǵ�, ���� �����̿� ���� �켱������ �����ּ���.
    public void SetCanvas(GameObject go, bool sort = true)
    {
        Canvas canvas = Util.GetOrAddComponent<Canvas>(go);
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.overrideSorting = true; //ĵ���� �ȿ� ĵ������ �־ �� �ȿ� ���ÿ����� ���´ٴ� ǥ��.

        if (sort)
        {
            canvas.sortingOrder = (_order);
            _order++;
        }
        else //popupUI �̿� ���� ����
        {
            canvas.sortingOrder = 0;
        }
            
    }

    public T ShowSceneUI<T>(string name = null) where T : UIScene
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        //�̹� ����������� ���������� ���� �����ش�.
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

        //�̹� ����������� ���������� ���� �����ش�.
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

        if(_popupStack.Peek() != popup) //Ȯ���ϰ� ������.
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
