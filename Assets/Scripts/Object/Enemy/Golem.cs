using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : EnemyBase
{
    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    protected override void OnReset()
    {
        HP = maxHp;
        isAlive = true;
    }

    protected override void OnMoveUpdate()
    {
        if (isDisappearing || transform.position.z < 0.1f)
        {
            moveDirection = Vector3.back;
        }
        else
        {
            moveDirection = (GameManager.Instance.Player.transform.position - transform.position).normalized;
        }
        transform.position += moveSpeed * Time.deltaTime * moveDirection;
        transform.forward = moveDirection;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetTrigger("Attack");

            isDisappearing = true;
            DisableTimer(1.5f);
        }
    }
}
