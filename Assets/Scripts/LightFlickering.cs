using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightFlickering : MonoBehaviour
{
    Light2D light;

    [Header("Intensity")]
    [SerializeField] bool flickIntensity = false;
    [SerializeField] float intensityRange;
    [SerializeField] float timeMin;
    [SerializeField] float timeMax;

    float baseIntensity;

    private void Awake()
    {
        light = GetComponent<Light2D>();
        baseIntensity = light.intensity;
        
    }

    private void Start()
    {
        StartCoroutine(FlickIntensity());
    }

    private IEnumerator FlickIntensity()
    {
        float t0 = Time.time;
        float t = t0;
        WaitUntil wait = new WaitUntil(() => Time.time > t0 + t);
        yield return new WaitForSeconds(Random.Range(0.01f, 0.05f));

        while (true)
        {
            if (flickIntensity)
            {
                t0 = Time.time;
                float r = Random.Range(baseIntensity - intensityRange, baseIntensity + intensityRange);
                light.intensity = r;
                t = Random.Range(timeMin, timeMax);
                yield return wait;
            }
            else yield return null;
        }
    }
}
