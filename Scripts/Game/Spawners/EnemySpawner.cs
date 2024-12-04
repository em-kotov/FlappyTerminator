using UnityEngine;

public class EnemySpawner : ZoneSpawner<Enemy>
{
    protected override void Create(Vector3 position)
    {
        int count = RandomExtensions.GetRandomNumber(1, Count);

        for (int i = 0; i < count; i++)
        {
            Enemy enemy = Pool.Pool.Get();
            enemy.Killed += OnKilled;
            Vector3 enemyPosition = RandomExtensions.GetRandomPosition(position, Radius);
            enemy.transform.position = enemyPosition;
            enemy.Initialize(enemyPosition, new Vector2(enemyPosition.x - 15f, enemyPosition.y));
            AddActive(enemy);
        }
    }

    protected override void DestroySingleItem(Enemy enemy)
    {
        if (enemy != null && ActiveObjects.Contains(enemy))
        {
            enemy.Deactivate();
            base.DestroySingleItem(enemy);
        }
    }

    private void OnKilled(Enemy enemy)
    {
        if (enemy != null && ActiveObjects.Contains(enemy))
        {
            enemy.Killed -= OnKilled;
            enemy.Deactivate();
            DestroySingleItem(enemy);
        }
    }
}
