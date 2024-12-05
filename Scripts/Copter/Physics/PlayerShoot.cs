using UnityEngine;

public class PlayerShoot : BulletSpawner
{
    [SerializeField] private Transform _shootTarget;

    public void FireBullet()
    {
        Bullet bullet = Pool.Pool.Get();
        bullet.SetEndPosition(_shootTarget.position);
        bullet.SetStartPosition(transform.position);
        bullet.SetMoveCoroutine(StartCoroutine(MoveBullet(bullet)));
        AddActive(bullet);
    }
}
