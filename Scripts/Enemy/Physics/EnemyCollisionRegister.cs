using System;
using UnityEngine;

public class EnemyCollisionRegister : MonoBehaviour
{
    public event Action<Bullet> WasShot;
    public event Action<Star> StarFound;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out IInteractable interactable))
        {
            if (interactable is Bullet)
            {
                WasShot?.Invoke(interactable as Bullet);
            }
            else if (interactable is Star)
            {
                StarFound?.Invoke(interactable as Star);
            }
        }
    }
}
