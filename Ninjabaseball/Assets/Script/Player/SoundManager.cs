using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] soundClips;

    private void Start()
    {
        // AudioSource ������Ʈ ��������
        audioSource = GetComponent<AudioSource>();
    }

    public void FinSound()
    {
        // "FinSound" �̺�Ʈ�� �´� ����� Ŭ�� ���
      
        
            // ���� ��� ù ��° ����� Ŭ���� ����� �� �ֽ��ϴ�.
            if (audioSource != null)
            {
                audioSource.clip = soundClips[0];
                audioSource.Play();
            }
        
    }

    public void AttackSound()
    {
        // "AttackSound" �̺�Ʈ�� �´� ����� Ŭ�� ���
       
        
            // ���� ��� �� ��° ����� Ŭ���� ����� �� �ֽ��ϴ�.
            if (audioSource != null)
            {
                audioSource.clip = soundClips[1];
                audioSource.Play();
            }
        
    }
}
