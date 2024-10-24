using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float interval = 5.0f;

    public float capacity = 10;

    [Tooltip ("X : 스폰지점 숲 속 좌표값, Y : 스폰지점 Y좌표 범위")]
    public Vector2 forestSpawnArea;
    [Tooltip ("X : 길 중앙으로 부터 거리, Y : none")]
    public Vector2 roadSpawnArea;

    Transform forestSpawn;
    Transform roadSpawn;

    bool isPlaying;
    public enum SpawnType
    {
        Goblin,
        Golem,
        Rock,
        Fence,
        Log
    }

    void Awake()
    {
        forestSpawn = transform.GetChild(0);
        roadSpawn = transform.GetChild(1);
    }

    void Start()
    {
        isPlaying = true;
        StartCoroutine(AutoSpawn());
    }

    IEnumerator AutoSpawn()
    {
        while (isPlaying)
        {
            float ran = Random.value;
            if (ran > 0.7f)
            {
                Spawn(SpawnType.Goblin);
            }
            else if (ran > 0.5f)
            {
                Spawn(SpawnType.Log);
            }
            else if (ran > 0.25f)
            {
                Spawn(SpawnType.Fence);
            }
            else if (ran > 0.1f)
            {
                Spawn(SpawnType.Rock);
            }
            else
            {
                Spawn(SpawnType.Golem);
            }
            yield return new WaitForSeconds(interval);
        }
    }

    void Spawn(SpawnType type)
    {
        Vector3 pos = (type == SpawnType.Goblin) ? RandomSpawnArea(0) : RandomSpawnArea(1);

        switch (type)
        {
            case SpawnType.Goblin:
                Factory.Instance.GetGoblin(pos); 
                break;
            case SpawnType.Golem:
                Factory.Instance.GetGolem(pos);
                break;
            case SpawnType.Rock:
                Factory.Instance.GetRock(pos);
                break;
            case SpawnType.Fence:
                Factory.Instance.GetFence(pos);
                break;
            case SpawnType.Log:
                Factory.Instance.GetLog(pos);
                break;
        }
    }

    Vector3 RandomSpawnArea(int index)
    {
        Vector3 result = Vector3.zero;
        float ran = Random.value;
        int lR = ran > 0.5 ? 1 : -1;

        if (index == 0)
        {
            // forest
            result = new Vector3(forestSpawnArea.x * lR, 0, Random.Range(forestSpawn.position.z + forestSpawnArea.y, forestSpawn.position.z - forestSpawnArea.y));
        }
        else
        {
            // road
            result = new Vector3(Random.Range(-5, 5), 0, roadSpawn.position.z);
        }

        return result;
    }

#if UNITY_EDITOR
    //void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //
    //    Vector3 p0 = new Vector3(forestSpawn.position.x + forestSpawnArea.x, 0, forestSpawn.position.z + forestSpawnArea.y);
    //    Vector3 p1 = new Vector3(forestSpawn.position.x - forestSpawnArea.x, 0, forestSpawn.position.z + forestSpawnArea.y);
    //
    //    Gizmos.DrawLine(p0, p1);
    //}
#endif
}
