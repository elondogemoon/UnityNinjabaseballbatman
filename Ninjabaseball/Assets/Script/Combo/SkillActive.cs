using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillActive : MonoBehaviour
{
    public KeyCode skillKey = KeyCode.Z; // 스킬을 발동할 키 설정
    public KeyCode directionKey = KeyCode.RightArrow; // 스킬을 발동할 방향키 설정

    private Queue<KeyCode> skillInputQueue = new Queue<KeyCode>(); // 스킬 입력을 위한 큐
    private Animator animator;
    public GameObject attackParticle;
    private Player player; 
    public AudioSource audiosource;
    private void Start()
    {
        player = GetComponent<Player>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // 스킬 키와 방향키를 입력받으면 큐에 추가
        if (Input.GetKeyDown(skillKey) && Input.GetKey(directionKey))
        {
            skillInputQueue.Enqueue(skillKey);
            skillInputQueue.Enqueue(directionKey);
        }

        // 스킬을 실행할 수 있는지 확인 후 실행
        CheckAndActiveSkill();
    }

    void CheckAndActiveSkill()
    {
        // 큐에 저장된 스킬 입력이 충분한지 확인
        if (skillInputQueue.Count >= 2)
        {
            // 큐에서 스킬 입력 데이터를 꺼내옴
            KeyCode inputSkillKey = skillInputQueue.Dequeue();
            KeyCode inputDirectionKey = skillInputQueue.Dequeue();

            // 스킬 발동 조건 확인
            if (inputSkillKey == skillKey && inputDirectionKey == directionKey)
            {
                // 스킬 실행
                ActiveSkill();
            }
        }
    }

    void ActiveSkill()
    {
        animator.SetBool("isSkill", true);
    }

    // 애니메이션 이벤트에서 호출할 함수
    public void SkillAnimationEnd()
    {
        
        animator.SetBool("isSkill", false);
    }
    public void ParticleBoom()
    {
        if (player != null)
        {
            Vector3 position = transform.position; // 현재 스크립트가 부착된 오브젝트의 위치
            Instantiate(attackParticle,player.AttackPoint.position , Quaternion.identity);
        }
        else
        {
            Debug.LogError("Player reference is null!");
        }
    }
    void SkillSound()
    {
        audiosource.Play();
    }
}
