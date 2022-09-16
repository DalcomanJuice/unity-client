using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Diagnostics;

public class UI_Inven : UIScene
{
    enum GameObjects
    {
        GridPanel,
    }
    
    void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        Bind<GameObject>(typeof(GameObjects));

        GameObject gridPanel = Get<GameObject>((int)GameObjects.GridPanel);
        //가지고 있는 자식들 모두 날리기.
        foreach (Transform child in gridPanel.transform)
        {
            Managers.Resource.Destroy(child.gameObject);
        }
        
        //실제 인벤토리 정보 참조
        for (int i = 0; i < 8; ++i)
        {
            GameObject item = Managers.Resource.Instantiate("UI/Scene/UI_Inven_Item");
            item.transform.SetParent(gridPanel.transform);

            //스크립트 상으로 컴포넌트 연결
            UI_Inven_Item uiInvenItem = Util.GetOrAddComponent<UI_Inven_Item>(item);
            uiInvenItem.SetInfo($"아이템 {i}");
        }
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
