using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class UIButton : UIBase
{
    [SerializeField] private Text _text; 
    
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
    enum GameObject
    {
        TestObject,
    }
    
    //리플렉션 기능을 사용한다.
    private void Start()
    {
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<UnityEngine.GameObject>(typeof(GameObject));
        //Test 
        Get<Text>((int)Texts.ScoreText).text = "Bind Text";
    }
    
    private int _score = 0;
    
    public void onButtonClicked()
    {
        _score++;
        _text.text = $"Score : {_score}";
    }
}
