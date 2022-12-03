using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float speed;

    public int points;
    Transform player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.Instance.player.transform;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Beam")
        {
            ScoreManager.Instance.AddScore(points);
            Destroy(collision.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * speed);
    }
}
