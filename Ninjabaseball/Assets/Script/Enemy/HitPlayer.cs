using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayer : MonoBehaviour
{
    public Animator animator;
    public int damage = 2;
    public BoxCollider2D hitBox;
    public float cooldown = 1f; // ���� ��Ÿ��
    private float currentCooldown = 0f; // ���� ��Ÿ��

    void Start()
    {
        animator = GetComponent<Animator>();
    }

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

        // ���� �ִϸ��̼� ���
        animator.SetBool("isAttack", true);

        // ���� �ִϸ��̼� ��� �� ��Ʈ�ڽ� ��Ȱ��ȭ
        StartCoroutine(DisableHitBoxAfterAnimation());
    }

    IEnumerator DisableHitBoxAfterAnimation()
    {
        // ���� �ִϸ��̼��� ���̸� ������
        float animationLength = animator.GetCurrentAnimatorStateInfo(0).length;

        // �ִϸ��̼� ����� ���� ������ ��ٸ�
        yield return new WaitForSeconds(animationLength);

        // ��Ʈ�ڽ� ��Ȱ��ȭ
        DisableHitBox();
    }


    // ��Ʈ�ڽ� ��Ȱ��ȭ
    public void DisableHitBox()
    {
        hitBox.enabled = false;
        animator.SetBool("isAttack", false);
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
