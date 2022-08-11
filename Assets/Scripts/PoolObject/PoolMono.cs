using System.Collections.Generic;
using UnityEngine;

public class PoolMono<T> where T : MonoBehaviour
{
    public T Prefab { get; }
    public bool AudtoExpand { get; set; }

    public Transform Container { get; }

    private List<T> _pool;

    public PoolMono(T prefab, int count) 
    {
        Prefab = prefab;
        Container = null;
    }

    public PoolMono(T prefab, int count, Transform container)
    {
        Prefab = prefab;
        Container = container;
        CreatePool(count);
    }

    private void CreatePool(int count) 
    {
        _pool = new List<T>();

        for (int i = 0; i < count; i++)
        {
            CreateObject();
        }
    }

    private T CreateObject(bool isActiveByDefault = false, Transform transform = null) 
    {
        T createdObject = Object.Instantiate(Prefab, Container);
        createdObject.gameObject.SetActive(isActiveByDefault);
        _pool.Add(createdObject);
        return createdObject;
    }

    public bool HasFreeElement(out T element, Transform transform = null) 
    {
        foreach(T prefab in _pool) 
        {
            if (!prefab.gameObject.activeInHierarchy)
            {
                element = prefab;
                if (transform)
                    prefab.gameObject.transform.position = transform.position;
                prefab.gameObject.SetActive(true);
                return true;
            }
        }
        element = null;
        return false;
    }

    public T GetFreeElemnt(Transform transform = null) 
    {
        if (HasFreeElement(out T element, transform))
            return element;

        if (AudtoExpand)
            return CreateObject(true);

        throw new System.Exception($"No free elements in pool of type {typeof(T)}");
    }


}
