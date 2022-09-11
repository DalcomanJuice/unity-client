using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor.UIElements;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Define.CameraMode _mode = Define.CameraMode.QuarterView;
    
    [SerializeField]
    private Vector3 _delta = new Vector3(0.0f, 6.0f, -5.0f );
    
    [SerializeField]
    private GameObject _player = null;
    
    void Start()
    {
        
    }
    
    //둘다 업데이트 문을 돈다. 한틱에 누가 먼저 호출될지 모른다. 그래서 덜덜 거린다 - 이럴경우 LateUpdate를 호출한다.
    void Update()
    {
        // transform.position = _player.transform.position + _delta;   //카메라 위치 이동
        // transform.LookAt(_player.transform);
    }

    private void LateUpdate()
    {
        if (_mode == Define.CameraMode.QuarterView)
        {
            transform.position = _player.transform.position + _delta;   //카메라 위치 이동
            transform.LookAt(_player.transform);    
        }
    }

    public void SetQuaterView(Vector3 delta)
    {
        _mode = Define.CameraMode.QuarterView;
        _delta = delta;
    }
}
