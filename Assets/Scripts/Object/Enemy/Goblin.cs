using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Goblin : EnemyBase
{ 
    public float appearTime = 3.0f;
    public float appearSpeed = 1.0f;

    bool isAppearing = false;

    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    protected override void OnReset()
    {
        HP = maxHp;
        isAlive = true;
        isAppearing = true;
        isDisappearing = false;
    }

    protected override void OnMoveUpdate()
    {
        if (isDisappearing || transform.position.z < 0.1f)
        {
            moveDirection = Vector3.back;
            transform.position += moveSpeed * Time.deltaTime * moveDirection;
            transform.forward = moveDirection;
        }
        else
        {
            if (isAppearing)
            {
                StartCoroutine(GoblinMove());
            }
            else
            {
                moveDirection = (GameManager.Instance.Player.transform.position - transform.position).normalized;
                transform.position += moveSpeed * Time.deltaTime * moveDirection;
                transform.forward = moveDirection;
            }
        }
        
    }

    IEnumerator GoblinMove()
    {
        float timeElapsed = 0.0f;

        while (timeElapsed < appearTime)
        {
            timeElapsed += Time.deltaTime;
            if (transform.position.x < 0)
            {
                moveDirection = (GameManager.Instance.Player.transform.position - transform.position).normalized + appearSpeed * Vector3.right;
                transform.forward = Vector3.right;
            }
            else if (transform.position.x > 0)
            {
                moveDirection = (GameManager.Instance.Player.transform.position - transform.position).normalized + appearSpeed * Vector3.left;
                transform.forward = Vector3.left;
            }
            yield return null;
        }
        isAppearing = false;
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
