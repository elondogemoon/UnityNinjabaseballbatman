using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayer : MonoBehaviour
{
    public Animator animator;
    public int damage = 2;
    public BoxCollider2D hitBox;
    public float cooldown = 1f; // 공격 쿨타임
    private float currentCooldown = 0f; // 현재 쿨타임

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 쿨타임 감소
        currentCooldown -= Time.deltaTime;

        // 쿨타임이 지나면 공격
        if (currentCooldown <= 0f)
        {
            Attack();
            currentCooldown = cooldown;
        }
    }

    void Attack()
    {
        // 히트박스 활성화
        hitBox.enabled = true;

        // 공격 애니메이션 재생
        animator.SetBool("isAttack", true);

        // 공격 애니메이션 재생 후 히트박스 비활성화
        StartCoroutine(DisableHitBoxAfterAnimation());
    }

    IEnumerator DisableHitBoxAfterAnimation()
    {
        // 현재 애니메이션의 길이를 가져옴
        float animationLength = animator.GetCurrentAnimatorStateInfo(0).length;

        // 애니메이션 재생이 끝날 때까지 기다림
        yield return new WaitForSeconds(animationLength);

        // 히트박스 비활성화
        DisableHitBox();
    }


    // 히트박스 비활성화
    public void DisableHitBox()
    {
        hitBox.enabled = false;
        animator.SetBool("isAttack", false);
    }

    // 플레이어에게 데미지 입히기
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Attack();
            other.GetComponent<PlayerController>().TakeDamage(damage);
        }
    }

    // 히트박스의 범위를 시각적으로 표시하기 위해 OnDrawGizmos 사용
    private void OnDrawGizmos()
    {
        if (hitBox != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(hitBox.bounds.center, hitBox.bounds.size);
        }
    }
}
