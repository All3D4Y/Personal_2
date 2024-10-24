using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;      // 다른 네임스페이스에서 제공하는 Random이 있어도 UnityEngine의 Random 사용

public class TestBase : MonoBehaviour
{
    
    TestInputActions inputActions;

    private void Awake()
    {
        inputActions = new TestInputActions();
    }

    private void OnEnable()
    {
        inputActions.Test.Enable();                     // Test액션맵 활성화하기
        inputActions.Test.Test1.performed += OnTest1;   // 액션과 함수 바인딩
        inputActions.Test.Test2.performed += OnTest2;
        inputActions.Test.Test3.performed += OnTest3;
        inputActions.Test.Test4.performed += OnTest4;
        inputActions.Test.Test5.performed += OnTest5;
        inputActions.Test.LClick.performed += OnTestLClick;
        inputActions.Test.RClick.performed += OnTestRClick;
        inputActions.Test.TestWASD.performed += OnTestWASD;
        inputActions.Test.TestWASD.canceled += OnTestWASD;
    }

    private void OnDisable()
    {
        inputActions.Test.TestWASD.canceled -= OnTestWASD;
        inputActions.Test.TestWASD.performed -= OnTestWASD;
        inputActions.Test.RClick.performed -= OnTestRClick;
        inputActions.Test.LClick.performed -= OnTestLClick;
        inputActions.Test.Test5.performed -= OnTest5;
        inputActions.Test.Test4.performed -= OnTest4;
        inputActions.Test.Test3.performed -= OnTest3;
        inputActions.Test.Test2.performed -= OnTest2;
        inputActions.Test.Test1.performed -= OnTest1;
        inputActions.Test.Disable();
    }

    protected virtual void OnTest1(InputAction.CallbackContext context)
    {
        //Debug.Log("부모 : OnTest1");
    }

    protected virtual void OnTest2(InputAction.CallbackContext context)
    {
    }

    protected virtual void OnTest3(InputAction.CallbackContext context)
    {
    }

    protected virtual void OnTest4(InputAction.CallbackContext context)
    {
    }

    protected virtual void OnTest5(InputAction.CallbackContext context)
    {
    }

    protected virtual void OnTestLClick(InputAction.CallbackContext context)
    {
    }

    protected virtual void OnTestRClick(InputAction.CallbackContext context)
    {
    }

    protected virtual void OnTestWASD(InputAction.CallbackContext context)
    {
    }
}
