using UnityEngine;
using System;

[RequireComponent(typeof(Collider2D))]
public class Star : MonoBehaviour, IInteractable
{
    private bool _isCollected = false;

    public event Action<Star> Collected;

    public void InvokeCollected()
    {
        if (_isCollected == false && gameObject.activeInHierarchy)
        {
            _isCollected = true;
            Collected?.Invoke(this);
        }
    }

    public void Deactivate()
    {
        _isCollected = false;
    }
}
