using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBase : EnemyBase
{
    protected override void OnReset()
    {
        HP = maxHp;
        isAlive = true;
    }

    protected override void OnMoveUpdate()
    {
        moveDirection = Vector3.back;
        transform.Translate(moveSpeed * Time.deltaTime * Vector3.back);
    }
}
