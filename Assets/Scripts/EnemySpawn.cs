using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    [SerializeField] GameObject enemyPrefab;

    Transform player;

    private float minSpawnDistance = 25f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.Instance.player.transform;
        InvokeRepeating("spawnEnemy", 1, 10);
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
        return center + Random.onUnitSphere * (minSpawnDistance + 15 * Random.value);
    }
}
