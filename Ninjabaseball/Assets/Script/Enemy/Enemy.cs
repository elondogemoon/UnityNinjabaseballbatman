using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 3f; // ���� �̵� �ӵ�
    public Transform playerTransform; // �÷��̾��� Transform
    public float followDistance = 5f; // �÷��̾ ���󰡴� �Ÿ�
    public float stopDistance = 2f; // ���ߴ� �Ÿ�
    public bool isDamage;
    private int health = 100; // ���� ü��
    int currenHp;
    Animator animator;
    Collider2D collider;
    bool isDead = false;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
        currenHp = health;
    }

    void Update()
    {
        if (!isDead)
        {
            // �÷��̾�� ���� ������ ���� ���
            Vector2 directionToPlayer = playerTransform.position - transform.position;

            // �÷��̾ ������ ���ʿ� �ִ��� Ȯ��
            bool isPlayerOnLeft = directionToPlayer.x < 0;

            // ���͸� �÷��̾� ������ ȸ��
            if (isPlayerOnLeft)
            {
                transform.localScale = new Vector3(-1, 1, 1); // ������ ������ �������� ����
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1); // �������� ������ �������� ����
            }

            // �÷��̾���� �Ÿ� ���
            float distanceToPlayer = directionToPlayer.magnitude;

            if (distanceToPlayer <= followDistance && distanceToPlayer > stopDistance)
            {
                // �÷��̾ ���� �̵�
                Vector2 movement = directionToPlayer.normalized * moveSpeed * Time.deltaTime;
                transform.Translate(movement);
            }
            else if (distanceToPlayer <= stopDistance)
            {
                // ���ߴ� ���� �߰�
            }
        }
    }



}
