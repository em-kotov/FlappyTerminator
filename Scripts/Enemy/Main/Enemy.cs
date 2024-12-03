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

    public void Initialize(Vector3 startPosition, Vector3 endPosition)
    {
        _mover.Initialize(startPosition, endPosition);
    }

    public void OnShot()
    {
        Killed?.Invoke(this);
    }
    
    public void OnStarFound(Star star)
    {
        star.gameObject.SetActive(false);
    }

    public void Deactivate()
    {
        _shoot.Deactivate();
        Destroy(gameObject);
    }
}
