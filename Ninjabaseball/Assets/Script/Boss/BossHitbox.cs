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
        // ��Ÿ�� ����
        currentCooldown -= Time.deltaTime;

        // ��Ÿ���� ������ ����
        if (currentCooldown <= 0f)
        {
            Attack();
            currentCooldown = cooldown;
        }
    }

    void Attack()
    {
        // ��Ʈ�ڽ� Ȱ��ȭ
        hitBox.enabled = true;
    }

    


    // ��Ʈ�ڽ� ��Ȱ��ȭ
    public void DisableHitBox()
    {
        hitBox.enabled = false;
    }

    // �÷��̾�� ������ ������
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Attack();
            other.GetComponent<PlayerController>().TakeDamage(damage);
        }
    }

    // ��Ʈ�ڽ��� ������ �ð������� ǥ���ϱ� ���� OnDrawGizmos ���
    private void OnDrawGizmos()
    {
        if (hitBox != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(hitBox.bounds.center, hitBox.bounds.size);
        }
    }
}
