using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Star : Collectible<Star>, IInteractable
{
    public void Initialize()
    {
        SetCollectibleItem(this);
    }
}
