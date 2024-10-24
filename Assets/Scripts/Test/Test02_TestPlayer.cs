using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test02_TestPlayer : MonoBehaviour
{
    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            animator.SetBool("IsAim", true);
        }
        else if (Input.GetMouseButtonUp(1))
        {
            animator.SetBool("IsAim", false);
        }
        else if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Fire");
            animator.SetFloat("RunFire", 0.25f);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            animator.SetFloat("RunFire", 0.0f);
        }

        else if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetFloat("DirY", 1.2f);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetFloat("DirX", -0.8f);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetFloat("DirX", 0.0f);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetFloat("DirX", 0.8f);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetFloat("DirX", 0.0f);
        }
    }
}
