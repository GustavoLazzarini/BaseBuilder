using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] int poolSize = 10;
    [SerializeField] bool poolCanExpand = true;
    private List<GameObject> pooledObjects;
    private GameObject parentObject;

    private void Start()
    {
        parentObject = new GameObject("Pool");
        Refill();
    }

    public void Refill()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            AddObjectToPool();
        }
    }

    public GameObject GetObjectFromPool()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        if (poolCanExpand)
        {
            return AddObjectToPool();
        }
        else
        {
            return null;
        }
    }

    public GameObject AddObjectToPool()
    {
        GameObject newObject = Instantiate(prefab);
        newObject.SetActive(false);
        newObject.transform.parent = parentObject.transform;
        pooledObjects.Add(newObject);
        return newObject;
    }
}
