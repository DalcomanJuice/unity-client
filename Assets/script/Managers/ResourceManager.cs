using UnityEngine;

public class ResourceManager
{
    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject prefab = Load<GameObject>($"Prefabs/{path}");
        if (null == prefab)
        {
            Debug.Log($"Failed to Load Prefab : {path}");
            return null;
        }
        return Object.Instantiate(prefab);  //prefab Object화.
    }

    public void Destroy(GameObject obj, float delTime = 0f)
    {
        _Destory(obj , delTime);
    }
    
    private void _Destory(GameObject obj, float delTime)
    {
        if (null == obj)
        {
            Debug.Log("Fail Destory Object");
            return;
        }
        Object.Destroy(obj, delTime);   
    }
}
