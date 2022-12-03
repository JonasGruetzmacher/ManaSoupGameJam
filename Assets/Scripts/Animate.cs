using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    Animator animator;

    public float horizontal;
    public float vertical;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        animator.SetFloat("Horizontal", horizontal);

        if (horizontal == 0 && vertical == 0) 
        {
            animator.SetBool("Moving", false);
            GetComponent<AudioSource>().mute = true;
        } else
        {
            animator.SetBool("Moving", true);
            GetComponent<AudioSource>().mute = false;
        }

    }
}
