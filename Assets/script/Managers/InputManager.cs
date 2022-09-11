using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public Action KeyAction = null;

    public Action<Define.MouseEvent> MouseAction = null;
    //Listener 패턴 .. 입력이 있을경우 event를 호출한다.

    private bool _pressed = false;
    public void onUpdate()
    {
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
