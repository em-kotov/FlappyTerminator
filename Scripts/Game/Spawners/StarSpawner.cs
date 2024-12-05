using UnityEngine;

public class StarSpawner : Spawner<Star>
{
    protected override void Create(Vector3 position)
    {
        int count = RandomExtensions.GetRandomNumber(MinCount, Count);

        for (int i = 0; i < count; i++)
        {
            Star star = Pool.Pool.Get();
            star.Collected += OnCollected;
            star.transform.position = RandomExtensions.GetRandomPosition(position, Radius);
            AddActive(star);
        }
    }

    private void OnCollected(Star star)
    {
        if (star != null && ActiveObjects.Contains(star))
        {
            star.Collected -= OnCollected;
            star.Deactivate();
            DestroySingleItem(star);
        }
    }
}
