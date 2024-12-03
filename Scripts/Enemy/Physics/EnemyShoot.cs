using System.Collections;
using UnityEngine;

public class EnemyShoot : Shoot
{
    [SerializeField] private float _fireInterval = 1.2f;
    [SerializeField] private float _bulletOffset = -4f;

    private void Start()
    {
        StartCoroutine(FireBullet());
    }

    public void Deactivate()
    {
        StopCoroutine(FireBullet());
        DestroyAllBullets();
    }

    private IEnumerator FireBullet()
    {
        WaitForSeconds wait = new WaitForSeconds(_fireInterval);

        while (enabled)
        {
            // Bullet bullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity); //get
            Bullet bullet = BulletSpawner.Pool.Get();
            bullet.SetEndPosition(new Vector2(transform.position.x + _bulletOffset, transform.position.y));
            bullet.SetStartPosition(transform.position);
            bullet.SetMoveCoroutine(StartCoroutine(MoveBullet(bullet)));
            _activeBullets.Add(bullet);

            yield return wait;
        }
    }
}
