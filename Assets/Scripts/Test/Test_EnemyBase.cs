using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_EnemyBase : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log(other.gameObject.name);
            EnemyBase enemyBase = other.GetComponent<EnemyBase>();
            Debug.Log(enemyBase.HP);
            Debug.Log(enemyBase.ATK);
        }
    }
}
