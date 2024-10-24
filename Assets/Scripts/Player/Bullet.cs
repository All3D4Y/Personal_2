using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : RecycleObject
{
    public float moveSpeed = 5.0f;

    void Start()
    {
        DisableTimer(0.8f);
    }
    void Update()
    {
        transform.Translate(0, 0, Time.deltaTime * moveSpeed);
    }
}
