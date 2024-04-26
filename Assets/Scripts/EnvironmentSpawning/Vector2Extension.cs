using UnityEngine;

namespace SourceCode.EnvironmentSpawning
{
    public static class Vector2Extension
    {
        public static Vector2 GetRandomDirection()
        {
            float xRandom = Random.Range(-1f, 1f);
            float yRandom = Random.Range(-1f, 1f);

            return new Vector2(xRandom, yRandom).normalized;
        }
        
        public static Vector2 GetPointOnCircle(Vector2 center, float minDistance, float maxDistance)
        {
            float randomDistance = Random.Range(minDistance, maxDistance);
            return center + GetRandomDirection() * randomDistance;
        }
        
        public static Vector2 GetRandom(Vector2 min, Vector2 max)
        {
            float xRandom = Random.Range(min.x, max.x + 1);
            float yRandom = Random.Range(min.y, max.y + 1);

            return new Vector2(xRandom, yRandom);
        }
    }
}