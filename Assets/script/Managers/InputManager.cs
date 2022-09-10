using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public Action KeyAction = null;

    //Listener 패턴 .. 입력이 있을경우 event를 호출한다.
    public void onUpdate()
    {
        if (Input.anyKey == false)  //chekc key input
            return;
        
        if(KeyAction != null)
            KeyAction.Invoke(); //특정 Key event 호출
    }
}
