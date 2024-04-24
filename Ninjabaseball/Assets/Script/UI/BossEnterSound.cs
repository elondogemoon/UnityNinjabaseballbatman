using UnityEngine;

public class BossEnterSound : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioSource audioSource;
    private Collider2D bossCollider;
    private bool hasPlayed = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioClip = GetComponent<AudioClip>();
        bossCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Player") && !hasPlayed)
        {
            audioSource.Play();
            hasPlayed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        if (otherCollider == bossCollider)
        {
            bossCollider.enabled = false;
            Destroy(audioSource);
        }
    }
}
