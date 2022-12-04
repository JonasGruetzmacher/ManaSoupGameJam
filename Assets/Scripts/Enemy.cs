using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] float speedIncrease;
    [SerializeField] ParticleSystem[] particlePrefab;

    public int points;
    Transform player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.Instance.player.transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Beam")
        {
            ScoreManager.Instance.AddScore(points);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * speed);

        if (EnemySpawn.increaseSpeed)
        {
            speed += speedIncrease;
            EnemySpawn.increaseSpeed = false;
        }
    }

    private void OnDestroy()
    {
        foreach (var p in particlePrefab)
        {
            Instantiate(p, transform.position, Quaternion.identity);
        }
        AudioManager.Instance.PlayAudio((int)Audio.GhostDie);
    }
}
