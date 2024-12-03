using UnityEngine;

public class StarSpawner : Spawner<Star>
{
    override protected void Create(Vector3 position)
    {
        int count = RandomExtensions.GetRandomNumber(1, Count);

        for (int i = 0; i < count; i++)
        {
            Star star = Instantiate(Prefab, position, Quaternion.identity); //get
            star.transform.position = RandomExtensions.GetRandomPosition(position, Radius);
            ActiveObjects.Add(star);
        }
    }
}
