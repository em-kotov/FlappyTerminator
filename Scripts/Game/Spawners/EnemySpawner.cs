using UnityEngine;

public class EnemySpawner : Spawner<Enemy>
{
    override public void ClearAllObjects()
    {
        foreach (Enemy enemy in ActiveObjects)
        {
            enemy.Deactivate();
        }

        ActiveObjects.Clear();
    }

    override protected void Create(Vector3 position)
    {
        int count = RandomExtensions.GetRandomNumber(1, Count);

        for (int i = 0; i < count; i++)
        {
            Enemy enemy = Instantiate(Prefab, position, Quaternion.identity);
            enemy.Killed += OnKilled;
            Vector3 enemyPosition = RandomExtensions.GetRandomPosition(position, Radius);
            enemy.transform.position = enemyPosition;
            enemy.Initialize(enemyPosition, new Vector2(enemyPosition.x - 15f, enemyPosition.y));
            ActiveObjects.Add(enemy);
        }
    }

    private void OnKilled(Enemy enemy)
    {
        enemy.Killed -= OnKilled;
        ActiveObjects.Remove(enemy);
        enemy.Deactivate();
    }
}
