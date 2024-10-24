using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : Singleton<Factory>
{
    //Pools
    GoblinPool goblin;
    GolemPool golem;
    RockPool rock;
    FencePool fence;
    LogPool log;
    BulletPool bullet;

    protected override void OnInitialize()
    {
        // 풀 초기화
        goblin = GetComponentInChildren<GoblinPool>();
        if (goblin != null)
            goblin.Initialize();

        golem = GetComponentInChildren<GolemPool>();
        if (golem != null)
            golem.Initialize();

        rock = GetComponentInChildren<RockPool>();
        if (rock != null)
            rock.Initialize();

        fence = GetComponentInChildren<FencePool>();
        if (fence != null)
            fence.Initialize();

        log = GetComponentInChildren<LogPool>();
        if (log != null)
            log.Initialize();
        
        bullet = GetComponentInChildren<BulletPool>();
        if (bullet != null)
            bullet.Initialize();
    }

    // 풀에서 오브젝트 가져오는 함수들 ------------------------------------------------------------------
    public Goblin GetGoblin(Vector3? position)
    {
        return goblin.GetObject(position);
    }
    public Golem GetGolem(Vector3? position)
    {
        return golem.GetObject(position);
    }
    public Rock GetRock(Vector3? position)
    {
        return rock.GetObject(position);
    }
    public Fence GetFence(Vector3? position)
    {
        return fence.GetObject(position);
    }
    public Log GetLog(Vector3? position)
    {
        return log.GetObject(position);
    }

    public Bullet GetBullet(Vector3? position)
    {
        return bullet.GetObject(position);
    }
}
