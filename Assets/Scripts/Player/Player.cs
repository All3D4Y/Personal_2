using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float moveSpeed = 1.0f;

    public float jumpPower = 1.0f;

    public float maxHp;

    public float baseATK;

    public float immuneTime;

    public float fireInterval = 0.3f;

    float hp;

    public float HP
    {
        get => hp;

        set
        {
            hp = value;
            if (hp <= 0.0f)
            {
                Die();
            }
        }
    }

    public float ATK => baseATK * GameManager.Instance.StageLevel;

    public Action onDie;

    bool isImmune = false;

    PlayerInput input;
    Transform firePos;

    Vector2 moveDir;
    Vector3 movePos;

    Animator animator;


    readonly int dirX = Animator.StringToHash("DirX");
    readonly int dirY = Animator.StringToHash("DirY");
    readonly int isAim = Animator.StringToHash("IsAim");
    readonly int fire = Animator.StringToHash("Fire");
    readonly int runFire = Animator.StringToHash("RunFire");

    void Awake()
    {
        input = new PlayerInput();
        //rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        firePos = transform.GetChild (0);
    }

    void Start()
    {
        HP = maxHp;
    }

    void OnEnable()
    {
        input.Player.Move.Enable ();
        input.Player.Fire.Enable ();
        input.Player.Jump.Enable ();
        input.Player.Slide.Enable ();
        input.Player.Aim.Enable ();
        input.Player.Move.performed += OnMovePerform;
        input.Player.Move.canceled += OnMoveCancle;
        input.Player.Fire.performed += OnFire;
        input.Player.Fire.canceled += OnFire_cancel;
        input.Player.Jump.performed += OnJump;
        input.Player.Slide.performed += OnSlide;
        input.Player.Aim.performed += OnAimPerform;
        input.Player.Aim.canceled += OnAimCancle;
    }


    void OnDisable()
    {
        input.Player.Move.performed -= OnMovePerform;
        input.Player.Move.canceled -= OnMoveCancle;
        input.Player.Fire.performed -= OnFire;
        input.Player.Fire.canceled -= OnFire_cancel;
        input.Player.Jump.performed -= OnJump;
        input.Player.Slide.performed -= OnSlide;
        input.Player.Aim.performed -= OnAimPerform;
        input.Player.Aim.canceled -= OnAimCancle;
        input.Player.Move.Disable ();
        input.Player.Fire.Disable();
        input.Player.Jump.Disable();
        input.Player.Slide.Disable();
        input.Player.Aim.Disable();
    }

    void Update()
    {
        movePos += moveSpeed * Time.deltaTime * (Vector3)moveDir;

        if (movePos.x > 5)
        {
            movePos.x = 5;
        }
        else if (movePos.x < -5)
        {
            movePos.x = -5;
        }

        transform.position = movePos;

        if (isImmune)
        {
            
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyBase enemybase = collision.gameObject.GetComponent<EnemyBase>();
            OnDamage(enemybase.ATK);
        }
    }

    void OnMovePerform(InputAction.CallbackContext context)
    {
        moveDir = context.ReadValue<Vector2>();
        animator.SetFloat(dirX, moveDir.x);
        animator.SetFloat(dirY, moveDir.y);
    }
    void OnMoveCancle(InputAction.CallbackContext context)
    {
        moveDir = Vector3.zero;
        animator.SetFloat(dirX, moveDir.x);
        animator.SetFloat(dirY, moveDir.y);
    }
    void OnFire(InputAction.CallbackContext context)
    {
        StartCoroutine(FireCoroutine());
    }
    void OnFire_cancel(InputAction.CallbackContext context)
    {
        StopAllCoroutines();
    }
    void OnJump(InputAction.CallbackContext context)
    {
        animator.SetTrigger("Jump");
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
    }

    void OnSlide(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    void OnAimPerform(InputAction.CallbackContext context)
    {
        animator.SetBool(isAim, true);
    }

   void OnAimCancle(InputAction.CallbackContext context)
    {
        animator.SetBool(isAim, false);
    }

    IEnumerator Delay(float time)
    {
        yield return new WaitForSeconds(time);
        animator.SetFloat(runFire, 0.0f);
    }

    void Fire()
    {
        Ray ray = new Ray(firePos.position, Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 40.0f))
        {
            EnemyBase enemy = hit.collider.gameObject.GetComponent<EnemyBase>();
            if (enemy != null)
            {
                Debug.Log(enemy.HP);
                enemy.GetDamage(ATK);
            }
        }
        Factory.Instance.GetBullet(firePos.position);
    }

    void OnDamage(float damage)
    {
        if (!isImmune)
        {
            HP -= damage;
            isImmune = true;
            animator.SetBool("IsImmune", isImmune);
            gameObject.layer = LayerMask.NameToLayer("Immune");
            StartCoroutine(ImmuneMode());
        }
    }

    void Die()
    {
        Debug.Log("Player Die");
        animator.SetBool("IsAlive", false);
        StartCoroutine(DieCoroutine());
    }

    IEnumerator ImmuneMode()
    {
        // immune mode animation start
        yield return new WaitForSeconds(immuneTime);
        // animation end
        gameObject.layer = LayerMask.NameToLayer("Player");
        isImmune = false;
        animator.SetBool("IsImmune", isImmune);
    }
    IEnumerator FireCoroutine()
    {
        while (true)
        {
            Fire();
            yield return new WaitForSeconds(fireInterval);
        }
    }

    IEnumerator DieCoroutine()
    {
        yield return new WaitForSeconds(1.0f);
        onDie?.Invoke();
        GameManager.Instance.StageOver();
    }

#if UNITY_EDITOR
    public void Test_Fire()
    {
        Fire();
    }
#endif
}
