using UnityEngine;
using UnityEngine.Pool;

public abstract class PoolSpawner<T> : MonoBehaviour where T : MonoBehaviour
{
    private T _prefab;
    private int _poolCapacity = 10;
    private int _poolMaxSize = 15;

    public ObjectPool<T> Pool { get; private set; }

    private void Awake()
    {
        Pool = new ObjectPool<T>(
            createFunc: () => OnCreate(),
            actionOnGet: (item) => OnGet(item),
            actionOnRelease: (item) => OnRelease(item),
            actionOnDestroy: (item) => Destroy(item.gameObject),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize);
    }

    public void SetPrefab(T prefab)
    {
        _prefab = prefab;
    }

    private void OnGet(T item)
    {
        item.gameObject.SetActive(true);
    }

    private void OnRelease(T item)
    {
        item.gameObject.SetActive(false);
    }

    private T OnCreate()
    {
        return Instantiate(_prefab);
    }
}
