using System.Collections;
using UnityEngine;

public class EnemyShoot : BulletSpawner
{
    [SerializeField] private float _fireInterval = 1.2f;
    [SerializeField] private float _bulletOffset = -4f;

    private Coroutine _fireCoroutine;

    public void Activate()
    {
        _fireCoroutine = StartCoroutine(FireBullet());
    }

    public void Deactivate()
    {
        StopFireCoroutine();
        DestroyAllObjects();
    }

    private void StopFireCoroutine()
    {
        if (_fireCoroutine != null)
        {
            StopCoroutine(_fireCoroutine);
            _fireCoroutine = null;
        }
    }

    private IEnumerator FireBullet()
    {
        WaitForSeconds wait = new WaitForSeconds(_fireInterval);

        while (enabled)
        {
            Bullet bullet = Pool.Get();
            bullet.Initialize(transform.position, new Vector2(transform.position.x
                                + _bulletOffset, transform.position.y));
            bullet.SaveCoroutine(StartCoroutine(MoveBullet(bullet)));
            AddActive(bullet);

            yield return wait;
        }

        _fireCoroutine = null;
    }
}
