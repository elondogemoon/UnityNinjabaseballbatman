using UnityEngine;

public class BossRoomEnter : MonoBehaviour
{
    public Animator animator;
    public Collider2D collisionCollider;
    public AudioSource audioSource;
    public AudioClip soundClip;
    public string triggerName = "PlayAnimation";
    public GameObject bossHealthbar;
    private bool animationPlaying = false;
    
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        soundClip = GetComponent<AudioClip>();
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (!animationPlaying)
            {
              
            PlayAnimation();
            }
        }
    }

    private void PlayAnimation()
    {
        animator.enabled = true;
        
        animationPlaying = true;
        
    }

    private void OnAnimationFinished()
    {
        bossHealthbar.SetActive(true);
        Destroy(gameObject);
        
    }

    public void PlaySound()
    {
        if (audioSource != null && soundClip != null)
        {
            audioSource.clip = soundClip;
            audioSource.Play();
        }
    }
}
