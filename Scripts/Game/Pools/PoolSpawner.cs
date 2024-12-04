using UnityEngine;
using UnityEngine.Pool;

public abstract class PoolSpawner<T> : MonoBehaviour where T : MonoBehaviour
{
    private T _prefab;
    private int _poolCapacity = 10;
    private int _poolMaxSize = 15;

    public ObjectPool<T> Pool { get; private set; }
    public int TotalQuantity { get; private set; }
    public int CreatedQuantity { get; private set; }
    public int ActiveQuantity { get; private set; }

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

        TotalQuantity = 0;
        CreatedQuantity = 0;
        ActiveQuantity = 0;
    }

    public void SetPrefab(T prefab)
    {
        _prefab = prefab;
    }

    private void OnGet(T item)
    {
        TotalQuantity++;
        ActiveQuantity++;
        item.gameObject.SetActive(true);
    }

    private void OnRelease(T item)
    {
        ActiveQuantity--;
        item.gameObject.SetActive(false);
    }

    private T OnCreate()
    {
        CreatedQuantity++;
        return Instantiate(_prefab);
    }
}
