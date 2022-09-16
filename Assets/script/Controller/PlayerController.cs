using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //인스펙터 창에 역 직렬화 할 경우 사용
    [SerializeField] private float _speed = 10.0f;

    private bool _moveToDest = false;
    private Vector3 _destPos;
    // Start is called before the first frame update
    void Start()
    {
        //혹여나 중복 구독을 막기 위해서 사용.
        Managers.Input.KeyAction -= onKeyBoard; 
        //어떤 키가 눌렸을 경우 해당 함수 호출되도록 구독 신청
        Managers.Input.KeyAction += onKeyBoard;
        Managers.Input.MouseAction -= onMouseClicked;
        Managers.Input.MouseAction += onMouseClicked;

        /*Managers.Resource.Instantiate("UI/UIButton");   //Prefab을 불러서사용.*/

        Managers.UI.ShowSceneUI<UI_Inven>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_moveToDest)
        {
            Vector3 dir = _destPos - transform.position;
            if (dir.magnitude < 0.0001f)
            {
                _moveToDest = false;
            }
            else
            {
                float moveDist = Math.Clamp(_speed * Time.deltaTime, 0, dir.magnitude) ; //이밸류는 min 과 맥스 값을 보장해야 한다.
                transform.position += dir.normalized * moveDist; //부들 수정
                //transform.position += dir.normalized * _speed * Time.deltaTime; //노멀라이즈 해서 이동시킨다. [해당 코드 문제가 있다.] 부들부들 거린다.
                
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 10 * Time.deltaTime);
                // transform.LookAt(_destPos); //이동 방향을 보면서 이동.
            }
        }
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

        _moveToDest = false;
    }

    void onMouseClicked(Define.MouseEvent evt)
    {
        if (evt != Define.MouseEvent.Click)
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100f, Color.red, 1.0f);
        
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100.0f, LayerMask.GetMask("Wall")))
        {
            //목적지로 가야 한다.
            _destPos = hit.point;
            _moveToDest = true;
        }
    }
}
