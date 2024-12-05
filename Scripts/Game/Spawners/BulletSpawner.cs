using System.Collections;
using UnityEngine;

public class BulletSpawner : Spawner<Bullet>
{
    [SerializeField] private float _bulletFlyTime = 0.5f;

    protected override void DestroySingleItem(Bullet bullet)
    {
        if (bullet != null && bullet.gameObject.activeInHierarchy && ActiveObjects.Contains(bullet))
        {
            if (bullet.MoveCoroutine != null)
            {
                StopCoroutine(MoveBullet(bullet));
                bullet.ResetMoveCoroutine();
            }

            ActiveObjects.Remove(bullet);
            Pool.Pool.Release(bullet);
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

        if (bullet != null)
        {
            bullet.ResetMoveCoroutine();
            DestroySingleItem(bullet);
        }
    }
}
