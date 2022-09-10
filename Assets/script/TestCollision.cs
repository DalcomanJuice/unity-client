using System;
using System.Collections;
using System.Collections.Generic;
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
        
    }
}
