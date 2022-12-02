using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float minSpawnDistance;
    [SerializeField] float spawnDistanceModifier;
    [SerializeField] float spawnTime;
    [SerializeField] float spawnDelay;

    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.Instance.player.transform;
        InvokeRepeating(nameof(spawnEnemy), spawnTime, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void spawnEnemy()
    {
        Vector3 spawnLocation = getSpawnSphere(player.position);
        Instantiate(enemyPrefab, spawnLocation, Quaternion.identity);
    }

    private Vector3 getSpawnSphere(Vector3 center)
    {
        return center + Random.onUnitSphere * (minSpawnDistance + spawnDistanceModifier * Random.value);
    }
}
