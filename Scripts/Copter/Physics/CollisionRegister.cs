using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class CollisionRegister : MonoBehaviour
{
    public event Action GroundFound;
    public event Action BulletFound;
    public event Action EnemyFound;
    public event Action<Star> StarFound;
    public event Action<ZoneController, float> NextZoneControllerFound;

    private void Awake()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out IInteractable interactable))
        {
            if (interactable is Ground)
                GroundFound?.Invoke();

            if (interactable is Star)
                StarFound?.Invoke(interactable as Star);

            if (interactable is ZoneController)
                NextZoneControllerFound?.Invoke(interactable as ZoneController,
                                                    transform.position.x);

            if (interactable is Enemy)
            {
                EnemyFound?.Invoke();
                // Debug.Log("Enemy collision");
            }

            if (interactable is Bullet)
            {
                BulletFound?.Invoke();
                // Debug.Log("Enemy bullet collision");
            }
        }
    }
}
