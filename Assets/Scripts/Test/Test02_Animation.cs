using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test02_Animation : MonoBehaviour
{
    Animator animator;

    readonly int IsAim = Animator.StringToHash("IsAim");
    readonly int IsSprint = Animator.StringToHash("IsSprint");
    readonly int IsDie = Animator.StringToHash("IsDie");
    readonly int Fire = Animator.StringToHash("Fire_Handgun");
    readonly int Jump = Animator.StringToHash("Jump");


    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            OnTest1();
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            OnTest2();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            OnTest3();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad4))
        {

        }
        else if (Input.GetKeyDown(KeyCode.Keypad5))
        {

        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            OnTestLClick();
        }
    }

    void OnTest1()
    {
        if (!animator.GetBool(IsAim))
        {
            animator.SetBool(IsAim, true);
        }
        else
        {
            animator.SetBool(IsAim, false);
        }
    }

    void OnTest2()
    {
        animator.SetTrigger(Jump);
    }

    void OnTest3()
    {
        if (!animator.GetBool(IsSprint))
        {
            animator.SetBool(IsSprint, true);
        }
        else
        {
            animator.SetBool(IsSprint, false);
        }
    }

    void OnTestLClick()
    {
        animator.SetTrigger(Fire);
    }
}
