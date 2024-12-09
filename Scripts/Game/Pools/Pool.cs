using UnityEngine;
using UnityEngine.Pool;

public abstract class Pool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private int PoolCapacity = 10;
    [SerializeField] private int PoolMaxSize = 15;

    private T _prefab;
    private ObjectPool<T> _pool;

    public int TotalQuantity { get; private set; }
    public int CreatedQuantity { get; private set; }
    public int ActiveQuantity { get; private set; }

    private void Awake()
    {
        _pool = new ObjectPool<T>(
            createFunc: () => OnCreate(),
            actionOnGet: (item) => OnGet(item),
            actionOnRelease: (item) => OnRelease(item),
            actionOnDestroy: (item) => Destroy(item.gameObject),
            collectionCheck: true,
            defaultCapacity: PoolCapacity,
            maxSize: PoolMaxSize);

        TotalQuantity = 0;
        CreatedQuantity = 0;
        ActiveQuantity = 0;
    }

    public T Get()
    {
        return _pool.Get();
    }

    public void Release(T item)
    {
        _pool.Release(item);
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
