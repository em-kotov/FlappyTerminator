using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private EnemyBullet _bulletPrefab;
    [SerializeField] private float _fireForce = 10f;
    [SerializeField] private float _fireInterval = 1.2f;

    private List<EnemyBullet> _activeBullets = new List<EnemyBullet>();

    private void Start()
    {
        StartCoroutine(FireBullet());
    }

    public void Deactivate()
    {
        StopCoroutine(FireBullet());
        ClearAllBullets();
    }

    private void ClearAllBullets()
    {
        for (int i = 0; i < _activeBullets.Count; i++)
        {
            if (_activeBullets[i] != null)
                Destroy(_activeBullets[i].gameObject);
        }

        _activeBullets.Clear();
    }

    private IEnumerator FireBullet()
    {
        WaitForSeconds wait = new WaitForSeconds(_fireInterval);

        while (enabled)
        {
            EnemyBullet bullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
            _activeBullets.Add(bullet);
            bullet.Rigidbody.AddForce(transform.right * -1 * _fireForce, ForceMode2D.Impulse);

            yield return wait;
        }
    }
}
