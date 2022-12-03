using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject beam;
    [SerializeField] float speed;
    [SerializeField] float fireRate;
    [SerializeField] int charges = 4;
    [SerializeField] Shield shield;

    [SerializeField] Sprite[] playerSprites;
    [SerializeField] SpriteRenderer spriteRenderer;

    Animate animate;
    float timeSinceLastBeam = 0f;
    Vector3 movement;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            charges--;
            if(charges < 0)
            {
                Debug.Log("Die");
            }
            Destroy(collision.gameObject);
        }
    }


    private void Awake()
    {
        animate = GetComponent<Animate>();
    }
    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;
        movement *= speed * Time.deltaTime;
        transform.position = transform.position + movement;

        animate.horizontal = movement.x;
        animate.vertical = movement.y;

        if (Input.GetMouseButton(0))
        {
            fireBeam();
        } else 
        { 
            timeSinceLastBeam += Time.deltaTime;
        }
    }

    private void fireBeam()
    {
        if (timeSinceLastBeam > fireRate && charges > 0)
        {
            AudioManager.Instance.PlayAudio((int)Audio.Beam);
            charges--;
            GetComponent<PlayerLights>().changePlayerLights(charges);
            beam.SetActive(true);
            timeSinceLastBeam = 0f;
            spriteRenderer.sprite = playerSprites[charges];
        }
    }

    public void AddCharge()
    {
        if (charges < 4)
        {
            
            charges++;
            spriteRenderer.sprite = playerSprites[charges];
        }

        GetComponent<PlayerLights>().changePlayerLights(charges);
        shield.charge += 20;
    }

}
