using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ZoneController : MonoBehaviour, IInteractable
{
    [SerializeField] private Transform _background;
    [SerializeField] private StarSpawner _starSpawner;
    [SerializeField] private EnemySpawner _enemySpawner;

    public void SetBackgroundPosition(float offset)
    {
        Vector3 newPosition = _background.position;
        newPosition.x += offset;
        _background.position = newPosition;
    }

    public void SpawnStars()
    {
        _starSpawner.Spawn();
    }

    public void SpawnEnemies()
    {
        _enemySpawner.Spawn();
    }

    public void ClearAllObjects()
    {
        _starSpawner.DestroyAllObjects();
        _enemySpawner.DestroyAllObjects();
    }

    public void ResetPosition(Vector3 position)
    {
        ClearAllObjects();
        _background.position = position;
    }
}
