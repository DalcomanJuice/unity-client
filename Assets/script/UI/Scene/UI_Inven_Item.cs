using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Inven_Item : UIBase
{
    enum GameObjects
    {
        ItemIcon,
        ItemNameText,
    }

    private string _name;
    // Start is called before the first frame update
    void Start()
    {
        Init();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Init()
    {
        Bind<UnityEngine.GameObject>(typeof(GameObjects));

        Get<GameObject>((int)GameObjects.ItemNameText).GetComponent<Text>().text = _name;
        
        Get<GameObject>((int)GameObjects.ItemIcon).AddUIEvent((PointerEventData) => { Debug.Log($"아이템 클릭 {_name}");});
    }

    public void SetInfo(string name)
    {
        _name = name;
    }
}
