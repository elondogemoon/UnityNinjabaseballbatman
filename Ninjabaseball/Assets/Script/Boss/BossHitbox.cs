using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHitbox : MonoBehaviour
{
    
    public int damage = 20;
    public BoxCollider2D hitBox;
    public float cooldown = 1f; 
    private float currentCooldown = 0f; 

    

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
    }

    


    // 히트박스 비활성화
    public void DisableHitBox()
    {
        hitBox.enabled = false;
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
