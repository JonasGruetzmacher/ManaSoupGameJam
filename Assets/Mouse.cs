using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    [SerializeField] float offsetX;
    [SerializeField] float offsetY;
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        pos.y += offsetY;
        pos.x += offsetX;
        transform.position = pos;
    }
}
