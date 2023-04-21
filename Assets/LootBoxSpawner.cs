using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBoxSpawner : MonoBehaviour
{
    [System.Serializable]
    public class LootBoxSpawnPoint
    {
        public Transform transform;
        public bool isOccupied;
    }

    public GameObject lootBoxPrefab;
    public int maxLootBoxes = 4;
    public float spawnDelay = 5f;
    public LootBoxSpawnPoint[] spawnPoints;

    private List<GameObject> spawnedLootBoxes = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(SpawnLootBoxes());
    }

    private IEnumerator SpawnLootBoxes()
    {
        while (true)
        {
            if (spawnedLootBoxes.Count < maxLootBoxes)
            {
                LootBoxSpawnPoint freeSpawnPoint = GetRandomFreeSpawnPoint();
                if (freeSpawnPoint.transform != null)
                {
               GameObject lootBoxObject = Instantiate(lootBoxPrefab, freeSpawnPoint.transform.position, Quaternion.identity);
                LootBox lootBox = lootBoxObject.GetComponent<LootBox>();
                lootBox.SetSpawnPoint(freeSpawnPoint);
                spawnedLootBoxes.Add(lootBoxObject);
                freeSpawnPoint.isOccupied = true;
                }
            }

            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private LootBoxSpawnPoint GetRandomFreeSpawnPoint()
    {
        List<LootBoxSpawnPoint> freeSpawnPoints = new List<LootBoxSpawnPoint>();

        foreach (LootBoxSpawnPoint spawnPoint in spawnPoints)
        {
            if (!spawnPoint.isOccupied)
            {
                freeSpawnPoints.Add(spawnPoint);
            }
        }

        if (freeSpawnPoints.Count > 0)
        {
            int randomIndex = Random.Range(0, freeSpawnPoints.Count);
            return freeSpawnPoints[randomIndex];
        }

        return new LootBoxSpawnPoint();
    }
}
