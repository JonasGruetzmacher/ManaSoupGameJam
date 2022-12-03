using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Beam : MonoBehaviour
{

    [SerializeField] float timeActive;
    float timeSinceActivation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceActivation += Time.deltaTime;
        if (timeSinceActivation > timeActive)
        {
            timeSinceActivation = 0f;
            gameObject.SetActive(false);
        }
    }
}
