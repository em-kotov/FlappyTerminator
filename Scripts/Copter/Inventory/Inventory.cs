using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
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
        StarCount = 0;
        StarCountChanged?.Invoke(StarCount);
    }
}
