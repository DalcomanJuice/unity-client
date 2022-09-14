using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;
using UnityEngine.EventSystems;

public class UIButton : UIPopup
{    
    enum Texts
    {
        PointText,
        ScoreText,
    }

    //컴포넌트
    enum Buttons
    {
        PointButton,
    }

    //Object Mapping
    enum GameObjects
    {
        TestObject,
    }
    
    enum Images
    {
        ItemIcon,
    }

    //리플렉션 기능을 사용한다.
    private void Start()
    {
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<UnityEngine.GameObject>(typeof(GameObjects));
        Bind<Image>(typeof(Images));
        //Test 
        
        GetButton((int)Buttons.PointButton).gameObject.AddUIEvent(onButtonClicked);

        UnityEngine.GameObject go = GetImages((int)Images.ItemIcon).gameObject;
        AddUIEvent(go, (PointerEventData data) => { go.transform.position = data.position; }, Define.UIEvent.Drag);        

        
    }
    
    private int _score = 0;
    
    public void onButtonClicked(PointerEventData data)
    {
        _score++;
        Get<Text>((int)Texts.ScoreText).text = $"Bind Text : {_score}";
    }
}
