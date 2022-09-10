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
     */
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("[OnCollision]");
    }

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
