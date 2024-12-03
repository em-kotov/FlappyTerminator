using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] protected Bullet _bulletPrefab;
    [SerializeField] protected float _bulletSpeed = 0.5f;

    protected List<Bullet> _activeBullets = new List<Bullet>();

    public void DestroyAllBullets()
    {
        if (_activeBullets.Count > 0)
        {
            for (int i = 0; i < _activeBullets.Count; i++)
            {
                if (_activeBullets[i] != null)
                    DestroySingleBullet(_activeBullets[i]);
            }

            _activeBullets.Clear();
        }
    }

    protected void DestroySingleBullet(Bullet bullet)
    {
        if (bullet.MoveCoroutine != null)
            StopCoroutine(MoveBullet(bullet));

        if (bullet != null)
        {
            Destroy(bullet.gameObject);
            _activeBullets.Remove(bullet);
        }
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

        bullet.ResetMoveCoroutine();
        DestroySingleBullet(bullet);
    }
}
