using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    [SerializeField] GameObject[] enemyPrefab;
    [SerializeField] float minSpawnDistance;
    [SerializeField] float spawnDistanceModifier;
    [SerializeField] float spawnTime;
    [SerializeField] float spawnDelay;
    [SerializeField] float minDistanceGroupSpawn;
    [SerializeField] float maxDistanceGroupSpawn;
    [SerializeField] int batchSize;

    [SerializeField] GameObject enemyParent;

    Transform player;
    float score;
    float timeSinceLastSpawn = 0f;
    float spawnDecrease = 0f;
    float scoreToNextStage = 500f;
    float scoreSinceLastStageIncrease = 0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.Instance.player.transform;
        InvokeRepeating(nameof(spawnEnemy), spawnTime, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        score = ScoreManager.Instance.score;
        float rand = Random.value;
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn > spawnDelay)
        {
            if (rand > 0.41f && rand < 0.9f)
            {
                spawnEnemy();
            }
            else if (rand > 0.91f)
            {
                spawnBatch();
            }
            timeSinceLastSpawn = 0f;
        }

/*
        scoreSinceLastStageIncrease += score;
        if (scoreSinceLastStageIncrease > scoreToNextStage)
        {
            spawnDelay -= 0.1f;
            scoreSinceLastStageIncrease = 0f;
        }
*/

    }

    private void spawnEnemy()
    {
        Vector3 spawnLocation = getSpawnSphere(player.position);
        Instantiate(enemyPrefab[Random.Range(0,enemyPrefab.Length)], spawnLocation, Quaternion.identity, enemyParent.transform);
    }

    private void spawnEnemyAtLocation(Vector3 spawnLocation)
    {
        Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)], spawnLocation, Quaternion.identity, enemyParent.transform);
    }

    private Vector3 getSpawnSphere(Vector3 center)
    {
        return center + Random.onUnitSphere * (minSpawnDistance + spawnDistanceModifier * Random.value);
    }

    private void spawnBatch()
    {
        List<Vector3> usedPositions = new List<Vector3>(batchSize);
        float minDistanceGroupSpawnSqr = minDistanceGroupSpawn * minDistanceGroupSpawn;
        float maxDistanceGroupSpawnSqr = maxDistanceGroupSpawn * maxDistanceGroupSpawn;

        for (int i = 0; i < batchSize; i++)
        {
            Vector3 spawnLocation = Vector3.zero;

            do
            {
                spawnLocation = getSpawnSphere(player.position);
            }
            while (isSpawnOutOfRange(spawnLocation, usedPositions, minDistanceGroupSpawnSqr, maxDistanceGroupSpawnSqr));

            spawnEnemyAtLocation(spawnLocation);
            usedPositions.Add(spawnLocation);
        }
        
    }

    private bool isSpawnOutOfRange(Vector3 spawnLocation, List<Vector3> usedPositions, float minDistanceGroupSpawnSqr, float maxDistanceGroupSpawnSqr)
    {
        foreach (var p in usedPositions)
        {
            float spawnDistanceSqr = (p - spawnLocation).sqrMagnitude;
            if ( spawnDistanceSqr <= minDistanceGroupSpawnSqr || spawnDistanceSqr >= maxDistanceGroupSpawnSqr)
            {
                return true;
            }
        }

        return false;
    }
}
