using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{

    public Stack<GameObject> itemPanelPool = new Stack<GameObject>();

    public static ObjectPoolManager Instance;

    public ObjectCollection objectCollection;

    private void Awake()
    {

    }

    private void Start()
    {

    }

    public void IniObjectPool(int poolCount)
    {
        for(int i = 0; i < poolCount; i++)
        {
            GameObject poolObject = GameObject.Instantiate(objectCollection.poolContext, objectCollection.poolContainer.transform);
            poolObject.SetActive(false);
            PushObject(poolObject);
        }
    }

    public void PushObject(GameObject poolObject)
    {
        itemPanelPool.Push(poolObject);
    }
    public GameObject PopObject()
    {
        if (itemPanelPool.Count == 0)
        {
            IniObjectPool(10);
        }
        return itemPanelPool.Pop();
    }
}
