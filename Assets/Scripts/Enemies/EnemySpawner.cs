using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float enemyMoveSpeed;
    public float spawnInterval = 20.0f;
    public float delayBetweenEnemies;
    public GameObject regEnemyPrefab;
    public Transform spawnPoints;
    public int enemiesPerWave = 3;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }
    private IEnumerator SpawnEnemies()
    {
        while(true)
        {
            for(int i = 0; i < enemiesPerWave; i++)
            {
                SpawnRegularEnemies();
                yield return new WaitForSeconds(delayBetweenEnemies);
            }
            yield return new WaitForSeconds(spawnInterval - delayBetweenEnemies * enemiesPerWave);
        }

    }
    private void SpawnRegularEnemies()
    {
        Transform spawnPoint = spawnPoints;
        GameObject enemy = Instantiate(regEnemyPrefab, spawnPoint.position, spawnPoint.rotation);
        UnityEngine.AI.NavMeshAgent enemyMeshAgent = enemy.GetComponent<UnityEngine.AI.NavMeshAgent>();
        enemyMeshAgent.speed = enemyMoveSpeed;
    }
}
