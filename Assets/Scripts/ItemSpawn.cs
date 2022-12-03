using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{

    [SerializeField] GameObject[] itemPrefab;
    [SerializeField] float spawnTime;
    [SerializeField] float spawnDelay;
    [SerializeField] Transform items;

    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnTime)
        {
            timer -= spawnTime;
            SpawnItem();
        }
    }

    void SpawnItem()
    {
        Vector3 pos = GameManager.Instance.player.transform.position;
        pos.x += Random.Range(-10,10);
        pos.y += Random.Range(-10, 10);
        Instantiate(itemPrefab[Random.Range(0,itemPrefab.Length)], pos, Quaternion.identity, items);

    }
}
