using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;

public abstract class Spawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected T Prefab;
    [SerializeField] protected float Radius = 3f;
    [SerializeField] protected int Count = 3;
    [SerializeField] protected int MinCount = 1;
    [SerializeField] protected PoolSpawner<T> Pool;
    [SerializeField] private Transform[] _spawnerZones;

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
