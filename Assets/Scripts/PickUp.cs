using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] ParticleSystem particlePrefab;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.Instance.player.GetComponent<Player>().AddCharge();
            AudioManager.Instance.PlayAudio((int)Audio.PickUp);
            Destroy(gameObject);

        }   
    }

    private void OnDestroy()
    {
        Instantiate(particlePrefab, transform.position, Quaternion.identity);
    }
}
