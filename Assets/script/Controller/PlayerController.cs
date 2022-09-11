using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //인스펙터 창에 역 직렬화 할 경우 사용
    [SerializeField] private float _speed = 10.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        //혹여나 중복 구독을 막기 위해서 사용.
        Managers.Input.KeyAction -= onKeyBoard; 
        //어떤 키가 눌렸을 경우 해당 함수 호출되도록 구독 신청
        Managers.Input.KeyAction += onKeyBoard; 
    }

    // Update is called once per frame
    void Update()
    {
        //transform.   
    }

    void onKeyBoard()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * Time.deltaTime * _speed;
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * Time.deltaTime * _speed;
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * Time.deltaTime * _speed;
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * Time.deltaTime * _speed;
        }
    }
}
