using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillActive : MonoBehaviour
{
    public KeyCode skillKey = KeyCode.Z; // ��ų�� �ߵ��� Ű ����
    public KeyCode directionKey = KeyCode.RightArrow; // ��ų�� �ߵ��� ����Ű ����

    private Queue<KeyCode> skillInputQueue = new Queue<KeyCode>(); // ��ų �Է��� ���� ť
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
        // ��ų Ű�� ����Ű�� �Է¹����� ť�� �߰�
        if (Input.GetKeyDown(skillKey) && Input.GetKey(directionKey))
        {
            skillInputQueue.Enqueue(skillKey);
            skillInputQueue.Enqueue(directionKey);
        }

        // ��ų�� ������ �� �ִ��� Ȯ�� �� ����
        CheckAndActiveSkill();
    }

    void CheckAndActiveSkill()
    {
        // ť�� ����� ��ų �Է��� ������� Ȯ��
        if (skillInputQueue.Count >= 2)
        {
            // ť���� ��ų �Է� �����͸� ������
            KeyCode inputSkillKey = skillInputQueue.Dequeue();
            KeyCode inputDirectionKey = skillInputQueue.Dequeue();

            // ��ų �ߵ� ���� Ȯ��
            if (inputSkillKey == skillKey && inputDirectionKey == directionKey)
            {
                // ��ų ����
                ActiveSkill();
            }
        }
    }

    void ActiveSkill()
    {
        animator.SetBool("isSkill", true);
    }

    // �ִϸ��̼� �̺�Ʈ���� ȣ���� �Լ�
    public void SkillAnimationEnd()
    {
        
        animator.SetBool("isSkill", false);
    }
    public void ParticleBoom()
    {
        if (player != null)
        {
            Vector3 position = transform.position; // ���� ��ũ��Ʈ�� ������ ������Ʈ�� ��ġ
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
