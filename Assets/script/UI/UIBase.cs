using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBase : MonoBehaviour
{
    private Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>();
    
    protected void Bind<T>(Type type) where T : UnityEngine.Object
    {
        String[] names = Enum.GetNames(type);
        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];
        _objects.Add(typeof(T), objects);

        for (int i = 0; i < names.Length; i++)
        {
            if(typeof(T) == typeof(UnityEngine.GameObject))
                objects[i] = Util.FindChild(gameObject, names[i], true);
            else //컴포넌트를 찾을 경우
                objects[i] = Util.FindChild<T>(gameObject, names[i], true);
            
            
        }
    }

    protected T Get<T>(int idex) where T : UnityEngine.Object
    {
        UnityEngine.Object[] objects = null;
        if (_objects.TryGetValue(typeof(T), out objects) == false)
            return null;

        return objects[idex] as T;
    }

    Text GetText(int idx) {
        return Get<Text>(idx);
    }

    Button GetButton(int idx) {
        return Get<Button>(idx);
    }
}
