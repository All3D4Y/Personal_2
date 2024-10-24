using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test05_EnemySpawner : MonoBehaviour
{
    Transform spawnPos;

    void Awake()
    {
        spawnPos = transform.GetChild(0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            Factory.Instance.GetGoblin(spawnPos.position);
    }
}
