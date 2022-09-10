using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabTest : MonoBehaviour
{
    private GameObject prefab;
    
    private GameObject player;
    void Start()
    {
        player = Managers.Resource.Instantiate("Player");
        Managers.Resource.Destroy(player , 3f);
    }
}
