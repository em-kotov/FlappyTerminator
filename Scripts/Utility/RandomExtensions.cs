using UnityEngine;

public static class RandomExtensions
{
    public static Vector3 GetRandomPosition(Vector3 position, float radius)
    {
        Vector3 randomPosition = Random.insideUnitSphere * radius;
        return randomPosition + position;
    }

    public static int GetRandomNumber(int min, int max)
    {
        return Random.Range(min, max);
    }
}