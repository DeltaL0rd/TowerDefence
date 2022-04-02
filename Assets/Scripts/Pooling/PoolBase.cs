using System.Collections.Generic;
using UnityEngine;

public abstract class PoolBase : MonoBehaviour
{
    public int poolSize;
    public GameObject objectPrefab;
    public List<PoolObject> pool;
    public Transform poolParent;

    private void Start()
    {
        pool = new List<PoolObject>();
        for (int i=0; i<poolSize; i++)
        {
            var obj = Instantiate(objectPrefab, poolParent).GetComponent<PoolObject>();
            pool.Add(obj);
        }
    }

    public PoolObject GetObject()
    {
        foreach(var obj in pool)
        {
            if (!obj.isActive)
                return obj;
        }

        // in case the pool is exhausted
        var newObj = Instantiate(objectPrefab, poolParent).GetComponent<PoolObject>();
        pool.Add(newObj);
        return newObj;
    }
}
