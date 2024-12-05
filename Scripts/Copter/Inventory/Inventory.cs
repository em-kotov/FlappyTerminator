using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    private int _startCount = 0;

    public event Action<int> StarCountChanged;

    public int StarCount { get; private set; } = 0;

    public void AddStar(Star star)
    {
        star.InvokeCollected();
        StarCount++;
        StarCountChanged?.Invoke(StarCount);
    }

    public void Reset()
    {
        StarCount = _startCount;
        StarCountChanged?.Invoke(StarCount);
    }
}
