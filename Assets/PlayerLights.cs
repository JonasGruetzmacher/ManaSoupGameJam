using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerLights : MonoBehaviour
{
    [SerializeField] Light2D[] fourCharges;
    [SerializeField] Light2D[] threeCharges;
    [SerializeField] Light2D[] twoCharges;
    [SerializeField] Light2D[] oneCharges;

    public void changePlayerLights(int charges)
    {
        foreach (Light2D light in oneCharges)
        {
            if(charges >= 1)
            {
                light.enabled = true;
            }
            else
            {
                light.enabled = false;
            }
        }
        foreach (Light2D light in twoCharges)
        {
            if (charges >= 2)
            {
                light.enabled = true;
            }
            else
            {
                light.enabled = false;
            }
        }
        foreach (Light2D light in threeCharges)
        {
            if (charges >= 3)
            {
                light.enabled = true;
            }
            else
            {
                light.enabled = false;
            }
        }
        foreach (Light2D light in fourCharges)
        {
            if (charges >= 4)
            {
                light.enabled = true;
            }
            else
            {
                light.enabled = false;
            }
        }
    }
}
