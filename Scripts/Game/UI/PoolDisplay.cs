using UnityEngine;
using System;
using TMPro;

public abstract class PoolDisplay<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _metricsText;
    [SerializeField] private PoolSpawner<T> _poolSpawner;

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
                            $"Total: {_poolSpawner.TotalQuantity}\n" +
                           $"Active: {_poolSpawner.ActiveQuantity}\n" +
                           $"Created: {_poolSpawner.CreatedQuantity}";
    }
}
