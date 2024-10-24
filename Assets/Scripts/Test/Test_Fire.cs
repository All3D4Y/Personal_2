using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test_Fire : TestBase
{
    public Transform fire;
    protected override void OnTest1(InputAction.CallbackContext context)
    {
        Factory.Instance.GetBullet(fire.position);
    }

    protected override void OnTest2(InputAction.CallbackContext context)
    {
        GameManager.Instance.Player.Test_Fire();
    }
}
