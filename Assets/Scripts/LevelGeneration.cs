using UnityEngine;
using Random = System.Random;

public class LevelGeneration : MonoBehaviour
{
    public GameObject[] PlatformPrefabs;
    public GameObject FirstPlatformPrefab;
    public int MinPlatforms;    
    public float DistanceBetweenPlatforms;
    public Transform FinishPlatform;
    public GameControllerScript Game;

    private void Awake()
    {
        int levelIndex = Game.LevelIndex;
        Random random = new Random(levelIndex);

        int platformsCount = RandomRange(random, MinPlatforms, MinPlatforms+levelIndex+1);
        
        for (int i = 0; i < platformsCount; i++)
        {
            int prefabIndex = RandomRange(random, 0, PlatformPrefabs.Length);
            
            GameObject platformPrefab = i == 0 ? FirstPlatformPrefab : PlatformPrefabs[prefabIndex];
            GameObject platform = Instantiate(platformPrefab, FirstPlatformPrefab.transform);

            platform.transform.localPosition = CalculatePlatformPosition(i);
        }

        FinishPlatform.localPosition = CalculatePlatformPosition(platformsCount);
    }

    private int RandomRange(Random random, int min, int maxExclusive) 
    {
        int number = random.Next(); 
        int length = maxExclusive - min; 
        number %= length; 
        return min + number; 
        
    }
    private float RandomRange(Random random, float min, float max)
    {
        float t = (float)random.NextDouble();
        return Mathf.Lerp(min, max, t);
    }

    private Vector3 CalculatePlatformPosition(int platformindex)
    {
        return new Vector3(0,0, DistanceBetweenPlatforms * platformindex);
    }
}
