using UnityEngine;
using System.Collections.Generic;

public abstract class Spawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected T Prefab;
    [SerializeField] private Transform[] _spawnerZones;
    [SerializeField] protected float Radius = 3f;
    [SerializeField] protected int Count = 3;

    protected List<T> ActiveObjects = new List<T>();

    public void Spawn()
    {
        foreach (Transform spawnerZone in _spawnerZones)
            Create(spawnerZone.position);
    }

    virtual public void ClearAllObjects()
    {
        foreach (T item in ActiveObjects)
            DestroyItem(item);

        ActiveObjects.Clear();
    }

    virtual protected void DestroyItem(T item)
    {
        Destroy(item.gameObject); //release
    }

    virtual protected void Create(Vector3 position) { }
}
