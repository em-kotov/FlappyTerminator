using UnityEngine;

public class StarSpawner : Spawner<Star>
{
    protected override void Create(Vector3 position)
    {
        int count = RandomExtensions.GetRandomNumber(MinCount, Count);

        for (int i = 0; i < count; i++)
        {
            Star star = Pool.Get();
            star.Initialize();
            star.Collected.AddListener(OnCollected);
            star.transform.position = RandomExtensions.GetRandomPosition(position, Radius);
            AddActive(star);
        }
    }

    private void OnCollected(Star star)
    {
        if (IsActive(star))
        {
            star.Deactivate();
            DestroySingleItem(star);
        }
    }
}
