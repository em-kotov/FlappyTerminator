using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;

public abstract class ZoneSpawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected T Prefab;
    [SerializeField] private Transform[] _spawnerZones;
    [SerializeField] protected float Radius = 3f;
    [SerializeField] protected int Count = 3;
    [SerializeField] protected PoolSpawner<T> Pool;

    protected HashSet<T> ActiveObjects = new HashSet<T>();

    private void Awake()
    {
        Pool.SetPrefab(Prefab);
    }

    public void Spawn()
    {
        foreach (Transform spawnerZone in _spawnerZones)
            Create(spawnerZone.position);
    }

    public virtual void DestroyAllObjects()
    {
        Array itemsToDestroy = ActiveObjects.ToArray();

        foreach (T item in itemsToDestroy)
            DestroySingleItem(item);

        ActiveObjects.Clear();
    }

    protected virtual void DestroySingleItem(T item)
    {
        if (item != null && item.gameObject.activeInHierarchy && ActiveObjects.Contains(item))
        {
            ActiveObjects.Remove(item);
            Pool.Pool.Release(item);
        }
    }

    protected virtual void AddActive(T item)
    {
        if (item != null && ActiveObjects.Contains(item) == false)
            ActiveObjects.Add(item);
    }

    protected virtual void Create(Vector3 position) { }
}
