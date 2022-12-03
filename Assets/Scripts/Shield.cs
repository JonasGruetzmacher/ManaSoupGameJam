using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] Transform shieldPivot;
    [SerializeField] float rechargeSpeed;
    [SerializeField] float charge = 100;

    public bool powered = true;

    Renderer renderer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && powered)
        {
            charge -= 20;
            ScoreManager.Instance.AddScore(collision.gameObject.GetComponent<Enemy>().points);
            Destroy(collision.gameObject);
            
        }
    }


    private void Start()
    {
        renderer = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        shieldPivot.transform.up = -(mousePosition - GameManager.Instance.player.transform.position);


        charge += rechargeSpeed * Time.deltaTime;
        if (charge > 100)
        {
            charge = 100;
        }

        if (charge <= 0)
        {
            powered = false;
            renderer.enabled = false;
        } else
        {
            powered = true;
            renderer.enabled = true;
        }

        var col = renderer.material.color;
        col.a = charge / 100f;
        renderer.material.color = col;
    }
}
