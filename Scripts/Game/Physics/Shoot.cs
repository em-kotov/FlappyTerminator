using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Shoot : MonoBehaviour
{
    [SerializeField] protected Bullet _bulletPrefab;
    [SerializeField] protected float _bulletSpeed = 0.5f;
    [SerializeField] protected BulletPool BulletSpawner;

    protected HashSet<Bullet> _activeBullets = new HashSet<Bullet>();

    private void Awake()
    {
        BulletSpawner.SetPrefab(_bulletPrefab);
    }

    public void DestroyAllBullets()
    {
        Array itemsToDestroy = _activeBullets.ToArray();

        foreach (Bullet item in itemsToDestroy)
            DestroySingleBullet(item);

        _activeBullets.Clear();
    }

    protected void DestroySingleBullet(Bullet bullet)
    {
        if (bullet != null && bullet.gameObject.activeInHierarchy && _activeBullets.Contains(bullet))
        {
            if (bullet.MoveCoroutine != null)
            {
                StopCoroutine(MoveBullet(bullet));
                bullet.ResetMoveCoroutine();
            }

            _activeBullets.Remove(bullet);
            BulletSpawner.Pool.Release(bullet);
        }
    }

    protected virtual void AddActive(Bullet item)
    {
        if (item != null && _activeBullets.Contains(item) == false)
            _activeBullets.Add(item);
    }

    protected IEnumerator MoveBullet(Bullet bullet)
    {
        float passedTime = 0f;

        while (bullet != null && passedTime < _bulletSpeed)
        {
            passedTime += Time.deltaTime;
            bullet.transform.position = Vector3.Lerp(bullet.StartPosition, bullet.EndPosition,
                                                                passedTime / _bulletSpeed);
            yield return null;
        }

        if (bullet != null)
        {
            bullet.ResetMoveCoroutine();
            DestroySingleBullet(bullet);
        }
    }
}
