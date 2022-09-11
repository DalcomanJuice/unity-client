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
            RaycastHit hit;
            if (Physics.Raycast(_player.transform.position, _delta, out hit, _delta.magnitude,
                    LayerMask.GetMask("Wall")))
            {
                float dist = (hit.point - _player.transform.position).magnitude * 0.8f; //방향벡터의 거리
                transform.position = _player.transform.position + _delta.normalized * dist;
            }
            else
            {
                transform.position = _player.transform.position + _delta; //카메라 위치 이동
                transform.LookAt(_player.transform);
            }
        }
    }

    public void SetQuaterView(Vector3 delta)
    {
        _mode = Define.CameraMode.QuarterView;
        _delta = delta;
    }
}
