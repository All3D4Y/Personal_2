using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class EnemyBase : RecycleObject
{
    public float maxHp;

    public float moveSpeed;

    public float exp;

    public float baseATK;

    protected bool isAlive = true;

    protected bool isDisappearing = false;

    protected Vector3 moveDirection;

    float hp;

    public float HP
    {
        get => hp;          // 읽기는 public
        set         // 쓰기는 private
        {
            hp = value;
            if (hp <= 0)      // 0이되면
            {
                Die();    // 사망 처리 수행
            }
        }
    }
    public float ATK
    {
        get => baseATK * GameManager.Instance.StageLevel;
    }

    void Update()
    {
        OnMoveUpdate();
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Weapon"))
        {
            float damage = GameManager.Instance.Player.ATK;
            GetDamage(damage);
        }
    }

    protected void Die()
    {
        if (isAlive) // 살아있을 때만 죽을 수 있음
        {
            isAlive = false;            // 죽었다고 표시
            //onDie?.Invoke(point);       // 죽었다고 등록된 객체들에게 알리기(등록된 함수 실행)

            //Factory.Instance.GetExplosion(transform.position);

            //OnDie();

            DisableTimer();     // 자신을 비활성화 시키기
        }
    }

    /// <summary>
    /// 이동관련 오버라이드 함수(빈 함수)
    /// </summary>
    protected virtual void OnMoveUpdate()
    {
    }

    public void GetDamage(float damage)
    {
        HP -= damage;
    }
}
