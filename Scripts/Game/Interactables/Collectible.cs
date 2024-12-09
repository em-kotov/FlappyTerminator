using UnityEngine;
using UnityEngine.Events;

public class Collectible<T> : MonoBehaviour where T : MonoBehaviour
{
    private bool _isCollected = false;
    private T _collectibleItem;

    public UnityEvent<T> Collected;

    public void InvokeCollected()
    {
        if (_isCollected == false && gameObject.activeInHierarchy)
        {
            _isCollected = true;
            Collected?.Invoke(_collectibleItem);
        }
    }

    public virtual void Deactivate()
    {
        Collected.RemoveAllListeners();
        _isCollected = false;
    }

    protected void SetCollectibleItem(T item)
    {
        _collectibleItem = item;
    }
}
