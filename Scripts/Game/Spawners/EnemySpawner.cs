using UnityEngine;

public class EnemySpawner : Spawner<Enemy>
{
    private float _positionOffset = -15f;

    protected override void Create(Vector3 position)
    {
        int count = RandomExtensions.GetRandomNumber(MinCount, Count);

        for (int i = 0; i < count; i++)
        {
            Enemy enemy = Pool.Get();
            enemy.Killed += OnKilled;
            Vector3 enemyPosition = RandomExtensions.GetRandomPosition(position, Radius);
            enemy.transform.position = enemyPosition;
            enemy.Initialize(new Vector2(enemyPosition.x + _positionOffset, enemyPosition.y));
            AddActive(enemy);
        }
    }

    protected override void DestroySingleItem(Enemy enemy)
    {
        if (IsActive(enemy))
        {
            enemy.Deactivate();
            base.DestroySingleItem(enemy);
        }
    }

    private void OnKilled(Enemy enemy)
    {
        if (IsActive(enemy))
        {
            enemy.Killed -= OnKilled;
            enemy.Deactivate();
            DestroySingleItem(enemy);
        }
    }
}
