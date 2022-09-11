using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager
{
    public Action KeyAction = null;

    public Action<Define.MouseEvent> MouseAction = null;
    //Listener 패턴 .. 입력이 있을경우 event를 호출한다.

    private bool _pressed = false;
    public void onUpdate()
    {
        //Ui호출 시 조건 추가
        if(EventSystem.current.IsPointerOverGameObject()) //지금 유아이 호출인지 아닌지 확인 가능
            return;

        if(Input.anyKey && KeyAction != null)
            KeyAction.Invoke(); //특정 Key event 호출

        if (MouseAction != null)
        {
            if (Input.GetMouseButton(0))
            {
                MouseAction.Invoke(Define.MouseEvent.Press);
                _pressed = true;
            }
            else
            {
                if(_pressed)
                    MouseAction.Invoke(Define.MouseEvent.Click);
                _pressed = false;
            }
            
        }
    }
}
