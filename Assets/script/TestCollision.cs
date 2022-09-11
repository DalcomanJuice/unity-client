using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    /**
     * condition
     * 1. 나한테 RegitBody 존재. IsKenematic : Off
     * 2. 나한테 Collider 존재 IsTrigger : off
     * 3. 상태한테 Collier 존재 IsTrigger : off
     * Collision 은 물리 연산을 한다.
     */
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("[OnCollision]");
    }

    /**
     * condition
     * 1. 둘다 Collider 가 있어야 한다.
     * 2. 둘중 하나는 isTrigger On 이여야 한다.   //Trigger가 발동한 개체만 있으면 될거같다. [Event 를 발생하는 주체]
     * 3. 둘중 하나는 RigidBody가 있어야 한다.
     */
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("[OnTrigger]");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //LayerTest();
    }

    void RayCastTest()
    {
        Vector3 look = transform.TransformDirection(Vector3.forward); //플레이어가 보는 forward를 월드 좌표로 변환한다.
        Debug.DrawRay(transform.position + Vector3.up, look * 10, Color.red);

        RaycastHit hit;
        if(Physics.Raycast(transform.position + Vector3.up, look, out hit, 10))
            Debug.Log($"RayCast : {hit.collider.gameObject.name}");
        
        
        RaycastHit[] raycastHits = Physics.RaycastAll(transform.position + Vector3.up, look, 10);
        foreach (RaycastHit element in raycastHits)
        {
            Debug.Log($"RayCast : {element.collider.gameObject.name}");
        }
    }

    void MouseTest()
    {
        /**
         * Screne의 마우스 좌표를 가져온다.
         */
        //Debug.Log(Input.mousePosition);
        
        /**
         * 화면 의 총 크기를 비율로 치환해 준다. (0.0 ~ 1.0)
         */
        //Debug.Log(Camera.main.ScreenToViewportPoint(Input.mousePosition));

        //깊이를 넣어줘야 하낟.
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);    //아래 코드와 동일한 역활을 한다.
            // Vector3 mousePosToWorld = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
            //     Input.mousePosition.y, Camera.main.nearClipPlane));
            // Vector3 dir = mousePosToWorld - Camera.main.transform.position;
            // dir = dir.normalized;
            
            Debug.DrawRay(Camera.main.transform.position, ray.direction * 100f, Color.red, 1.0f);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 100.0f))
                Debug.Log($"{hit.collider.gameObject.name}");
            
            // if (Physics.Raycast(Camera.main.transform.position, dir, out hit))
            //     Debug.Log($"{hit.collider.gameObject.name}");
        }
    }
    
    //Tag는 특정 그룹으로 Object를 묶을 경우 사용한다.
    //

    void LayerTest()
    {
        /**
         * layerMask는 bitFlag를 사용환다.
         * Wall = 8
         * Monster = 9
         */
        int mask = (1 << 9) | (1 << 8);

        LayerMask layerMask = LayerMask.GetMask("Monster") | LayerMask.GetMask("Wall");
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100f, Color.red, 1.0f);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 100.0f, layerMask))
            Debug.Log($"{hit.collider.gameObject.name}");
    }

    void Tag()
    {
        /**
         * GameOjectWithTag. 로 Tage 로 가져올 수 있다.
         */
        GameObject.FindGameObjectWithTag("TagName");
    }
}
