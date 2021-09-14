using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Helper class for pooling objects
public static class ObjectPooler
{
    public static List<GameObject> CreateObjectPool(int _amountToPool, GameObject _objectToPool)
    {
        List<GameObject> pooledObjects = new List<GameObject>();

        for (int i = 0; i < _amountToPool; i++)
        {
            GameObject obj = GameObject.Instantiate(_objectToPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
        return pooledObjects;
    }

    public static GameObject GetPooledObject(List<GameObject> _pooledObjects)
    {
        for (int i = 0; i < _pooledObjects.Count; i++)
        {
            if (!_pooledObjects[i].activeInHierarchy)
            {
                return _pooledObjects[i];
            }
        }

        return null;
    }

    // Assign parent grouping to clean the hierarchy up in the editor
    public static List<GameObject> AssignParentGrouping(List<GameObject> _pooledObjects, Transform _parent)
    {
        for (int i = 0; i < _pooledObjects.Count; i++)
        {
            _pooledObjects[i].transform.parent = _parent;
        }

        return _pooledObjects;
    }
}

