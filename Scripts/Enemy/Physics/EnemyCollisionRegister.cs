using System;
using UnityEngine;

public class EnemyCollisionRegister : MonoBehaviour
{
    public event Action WasShot;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.TryGetComponent(out Bullet bullet))
        {
            WasShot?.Invoke();
        }
    }
}
