using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class Boss : MonoBehaviour
{
    public float moveSpeed = 3f; // 몬스터 이동 속도
    public Transform playerTransform; // 플레이어의 Transform
    public float followDistance = 5f; // 플레이어를 따라가는 거리
    public float stopDistance = 2f; // 멈추는 거리
    public bool isDamage;
    private int health = 100; // 몬스터 체력
    int currenHp;
    Animator animator;
    Collider2D collider;
    bool isDead = false;
    public EnemyEx bossenemy;
    
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
        currenHp = health;
        bossenemy = FindObjectOfType<EnemyEx>();
    }
    void Ending()
    {
        if (bossenemy.currentHp <= 0)
        {
            Debug.Log("ㅅㅂ");
            StartCoroutine(DestroyAfterDelay(3f));
            
        }
    }
    IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

    }
    void Update()
    {
        if (!isDead)
        {
            // 플레이어와 몬스터 사이의 벡터 계산
            Vector2 directionToPlayer = playerTransform.position - transform.position;

            // 플레이어가 몬스터의 왼쪽에 있는지 확인
            bool isPlayerOnLeft = directionToPlayer.x < 0;

            // 몬스터를 플레이어 쪽으로 회전
            if (isPlayerOnLeft)
            {
                transform.localScale = new Vector3(1, 1, 1); // 왼쪽을 보도록 스케일을 조절
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1); // 오른쪽을 보도록 스케일을 조절
            }

            // 플레이어와의 거리 계산
            float distanceToPlayer = directionToPlayer.magnitude;

            if (distanceToPlayer <= followDistance && distanceToPlayer > stopDistance)
            {
                // 플레이어를 향해 이동
                Vector2 movement = directionToPlayer.normalized * moveSpeed * Time.deltaTime;
                transform.Translate(movement);
            }
            else if (distanceToPlayer <= stopDistance)
            {
                // 멈추는 로직 추가
            }
        }
    }
    
    



}
