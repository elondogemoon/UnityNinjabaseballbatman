using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] soundClips;

    private void Start()
    {
        // AudioSource 컴포넌트 가져오기
        audioSource = GetComponent<AudioSource>();
    }

    public void FinSound()
    {
        // "FinSound" 이벤트에 맞는 오디오 클립 재생
      
        
            // 예를 들어 첫 번째 오디오 클립을 재생할 수 있습니다.
            if (audioSource != null)
            {
                audioSource.clip = soundClips[0];
                audioSource.Play();
            }
        
    }

    public void AttackSound()
    {
        // "AttackSound" 이벤트에 맞는 오디오 클립 재생
       
        
            // 예를 들어 두 번째 오디오 클립을 재생할 수 있습니다.
            if (audioSource != null)
            {
                audioSource.clip = soundClips[1];
                audioSource.Play();
            }
        
    }
}
