using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    public Animator animator;
    public Transform AttackPoint;
    public LayerMask enemyLayers;
    public GameObject VFXPrefab;
    public AudioSource hurtaudio;
    public float vfxDuration = 1.0f;    
    
    public int atkDmg = 40;
    public float attackRange = 0.5f;
    public bool isAttacking = false;
    public bool isSkill = false;
    public static Player instance;
    private void Awake()
    {
        instance = this;
    }

    Rigidbody2D rb;

    [SerializeField] float speed = 3.0f;

    // 공격 쿨타임을 관리할 변수
    private float curTime;
    public float coolTime = 0.5f;
    public Transform pos;
    public Vector2 boxSize;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !isAttacking)
        {
            isAttacking = true;
            Attack();
        }


    }
    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            EnemyEx enemyEx = enemy.GetComponent<EnemyEx>();
            if (enemyEx != null)
            {
                enemyEx.TakeDamage(20);
                GameObject vfxInstance = Instantiate(VFXPrefab, AttackPoint.position, Quaternion.identity);
                Destroy(vfxInstance, vfxDuration);
            }

            BreakDoor breakDoor = enemy.GetComponent<BreakDoor>();
            if (breakDoor != null)
            {
                breakDoor.TakeDamage(20);
            }
        }
        
    }
    void hurtSound()
    {
        hurtaudio.Play();
    }

    private void OnDrawGizmosSelected()
    {
        if (AttackPoint == null)
            return;
        Gizmos.DrawWireSphere(AttackPoint.position,attackRange);
    }
   


}
