using UnityEngine;

public class PlayerShoot : BulletSpawner
{
    [SerializeField] private Transform _shootTarget;

    public void FireBullet()
    {
        Bullet bullet = Pool.Get();
        bullet.Collected.AddListener(OnCollected);
        bullet.Initialize(transform.position, _shootTarget.position);
        bullet.SaveCoroutine(StartCoroutine(MoveBullet(bullet)));
        AddActive(bullet);
    }
}
