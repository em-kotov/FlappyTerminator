using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;

public abstract class Spawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected float Radius = 3f;
    [SerializeField] protected int Count = 3;
    [SerializeField] protected int MinCount = 1;
    [SerializeField] protected Pool<T> Pool;

    [SerializeField] private T _prefab;
    [SerializeField] private Transform[] _spawnerZones;

    private HashSet<T> _activeObjects = new HashSet<T>();

    private void Awake()
    {
        Pool.SetPrefab(_prefab);
    }

    public void Spawn()
    {
        foreach (Transform spawnerZone in _spawnerZones)
            Create(spawnerZone.position);
    }

    public void DestroyAllObjects()
    {
        Array itemsToDestroy = _activeObjects.ToArray();

        foreach (T item in itemsToDestroy)
            DestroySingleItem(item);

        _activeObjects.Clear();
    }

    protected virtual void DestroySingleItem(T item)
    {
        if(IsActive(item))
        {
            _activeObjects.Remove(item);
            Pool.Release(item);
        }
    }

    protected virtual void Create(Vector3 position) { }

    protected void AddActive(T item)
    {
        if (item != null && _activeObjects.Contains(item) == false)
            _activeObjects.Add(item);
    }

    protected bool IsActive(T item)
    {
        return item != null && item.gameObject.activeInHierarchy && _activeObjects.Contains(item);
    }
}
