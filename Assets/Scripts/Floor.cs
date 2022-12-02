using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    [SerializeField] Vector2Int tilePosition;

    private void Start()
    {
        GetComponentInParent<BackgroundSpawner>().Add(gameObject, tilePosition);

        transform.position = new Vector3(-100, 100,0);
    }
}
