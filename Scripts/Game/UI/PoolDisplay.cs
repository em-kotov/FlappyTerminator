using UnityEngine;
using System;
using TMPro;

public abstract class PoolDisplay<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _metricsText;
    [SerializeField] private Pool<T> _pool;

    private Type _type;

    private void Awake()
    {
        _type = typeof(T);
    }

    private void Update()
    {
        DisplayMetrics();
    }

    private void DisplayMetrics()
    {
        _metricsText.text = $"{_type.Name}\n" +
                            $"Total: {_pool.TotalQuantity}\n" +
                           $"Active: {_pool.ActiveQuantity}\n" +
                           $"Created: {_pool.CreatedQuantity}";
    }
}
