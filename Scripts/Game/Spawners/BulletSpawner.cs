using System.Collections;
using UnityEngine;

public class BulletSpawner : Spawner<Bullet>
{
    [SerializeField] private float _bulletFlyTime = 0.5f;

    protected override void DestroySingleItem(Bullet bullet)
    {
        if (IsActive(bullet))
        {
            bullet.Deactivate();
            base.DestroySingleItem(bullet);
        }
    }

    protected IEnumerator MoveBullet(Bullet bullet)
    {
        float passedTime = 0f;

        while (bullet != null && passedTime < _bulletFlyTime)
        {
            passedTime += Time.deltaTime;
            bullet.transform.position = Vector3.Lerp(bullet.StartPosition, bullet.EndPosition,
                                                                passedTime / _bulletFlyTime);
            yield return null;
        }

        DestroySingleItem(bullet);
    }

    protected void OnCollected(Bullet bullet)
    {
        DestroySingleItem(bullet);
    }
}
