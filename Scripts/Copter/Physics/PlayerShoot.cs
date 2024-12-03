using UnityEngine;

public class PlayerShoot : Shoot
{
    [SerializeField] private Transform _shootTarget;

    public void FireBullet()
    {
        // Bullet bullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity); //get
        Bullet bullet = BulletSpawner.Pool.Get();
        bullet.SetEndPosition(_shootTarget.position);
        bullet.SetStartPosition(transform.position);
        bullet.SetMoveCoroutine(StartCoroutine(MoveBullet(bullet)));
        _activeBullets.Add(bullet);
    }
}
