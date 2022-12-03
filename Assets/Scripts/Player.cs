using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject beam;
    [SerializeField] float speed;
    [SerializeField] float fireRate;

    float timeSinceLastBeam = 0f;
    Vector3 movement;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Debug.Log("DIE!!");

        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;
        movement *= speed * Time.deltaTime;
        transform.position = transform.position + movement;

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
        if (timeSinceLastBeam > fireRate)
        {
            beam.SetActive(true);
            timeSinceLastBeam = 0f;
        }
    }
}
