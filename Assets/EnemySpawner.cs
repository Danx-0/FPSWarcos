using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> enemyPrefabList = new List<GameObject>();

    [SerializeField]
    private List<Transform> spawnPointList = new List<Transform>();

    [SerializeField]
    private float timeBetweenSpawns = 10f;

    private float timeSinceLastSpawn = 0f;

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= timeBetweenSpawns)
        {
            timeSinceLastSpawn = 0f;
            SpawnRandomEnemy();
        }
    }

    void SpawnRandomEnemy()
    {
        int randomEnemyNum = Random.Range(0, enemyPrefabList.Count);
        int randomSpawnPoint = Random.Range(0, spawnPointList.Count);

        GameObject newEnemy = Instantiate(enemyPrefabList[randomEnemyNum], spawnPointList[randomSpawnPoint].position, Quaternion.identity);

        newEnemy.GetComponent<EnemyScript>().patrolPoint = spawnPointList;
    

    }
}