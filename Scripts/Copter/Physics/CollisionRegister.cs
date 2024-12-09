using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class CollisionRegister : MonoBehaviour
{
    public event Action GroundFound;
    public event Action BulletFound;
    public event Action EnemyFound;
    public event Action<Star> StarFound;
    public event Action<ZoneController> NextZoneControllerFound;

    private void Awake()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out IInteractable interactable))
        {
            if (interactable is Ground)
            {
                GroundFound?.Invoke();
            }
            else if (interactable is Star)
            {
                StarFound?.Invoke(interactable as Star);
            }
            else if (interactable is ZoneController)
            {
                NextZoneControllerFound?.Invoke(interactable as ZoneController);
            }
            else if (interactable is Enemy)
            {
                EnemyFound?.Invoke();
            }
            else if (interactable is Bullet)
            {
                BulletFound?.Invoke();
            }
        }
    }
}
