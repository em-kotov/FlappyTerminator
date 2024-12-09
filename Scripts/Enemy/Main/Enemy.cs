using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IInteractable
{
    [SerializeField] private EnemyMover _mover;
    [SerializeField] private EnemyShoot _shoot;
    [SerializeField] private EnemyCollisionRegister _collisionRegister;

    public event Action<Enemy> Killed;

    private void OnEnable()
    {
        _collisionRegister.WasShot += OnShot;
        _collisionRegister.StarFound += OnStarFound;
    }

    private void OnDisable()
    {
        _collisionRegister.WasShot -= OnShot;
        _collisionRegister.StarFound -= OnStarFound;
    }

    public void Initialize(Vector3 endPosition)
    {
        _mover.Initialize(endPosition);
        _shoot.Activate();
    }

    public void OnShot(Bullet bullet)
    {
        bullet.InvokeCollected();
        Killed?.Invoke(this);
    }

    public void OnStarFound(Star star)
    {
        star.InvokeCollected();
    }

    public void Deactivate()
    {
        _shoot.Deactivate();
    }
}
