using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateEnemy : MonoBehaviour
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
        horizontal = GameManager.Instance.player.transform.position.x - transform.position.x;
        animator.SetFloat("Horizontal", horizontal);
    }
}
