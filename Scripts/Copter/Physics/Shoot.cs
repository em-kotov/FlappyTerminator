using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _bulletSpeed = 0.5f;
    [SerializeField] private Transform _shootTarget;

    private List<Bullet> _activeBullets = new List<Bullet>();

    public void FireBullet()
    {
        DestroyOldBullets();

        Bullet bullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
        bullet.SetEndPosition(_shootTarget.position);
        bullet.SetStartPosition(transform.position);
        bullet.SetMoveCoroutine(StartCoroutine(MoveBullet(bullet)));
        _activeBullets.Add(bullet);
    }

    public void ClearAllBullets()
    {
        if (_activeBullets.Count > 0)
        {
            for (int i = 0; i < _activeBullets.Count; i++)
            {
                if (_activeBullets[i] != null)
                    ClearSingleBullet(_activeBullets[i]);
            }

            _activeBullets.Clear();
        }
    }

    private void DestroyOldBullets()
    {
        for (int i = 0; i < _activeBullets.Count; i++)
        {
            if (CanDestroy(_activeBullets[i]))
                ClearSingleBullet(_activeBullets[i]);
        }
    }

    private IEnumerator MoveBullet(Bullet bullet)
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
        ClearSingleBullet(bullet);
    }

    private void ClearSingleBullet(Bullet bullet)
    {
        if (bullet.MoveCoroutine != null)
            StopCoroutine(MoveBullet(bullet));

        if (bullet != null)
        {
            Destroy(bullet.gameObject);
            _activeBullets.Remove(bullet);
        }
    }

    private bool CanDestroy(Bullet bullet)
    {
        if (bullet.transform.position.x >= bullet.EndPosition.x && bullet != null)
            return true;

        return false;
    }
}
