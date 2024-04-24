using UnityEngine;
using System.Collections;
public class BossPattern : MonoBehaviour
{
    public EnemyEx EnemyEx;
    private int nextPattern = 0;
    private Animator animator;
    private Rigidbody2D rb;
    public AudioSource audioSource;

    public AudioClip windSound;
    public AudioClip punchSound;
    public AudioClip uppercutSound;
    public AudioClip movingSound;

    private static readonly int Idle = 0;
    private static readonly int Wind = 1;
    private static readonly int Punch = 2;
    private static readonly int Uppercut = 3;
    private static readonly int Moving = 4;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        StartCoroutine("punch");
    }
    private void Update()
    {
        if (EnemyEx.currentHp <= 0)
        {
            StopAllCoroutines();
        }
    }
    IEnumerator wind()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        float pushForce = 3f;

        Vector3 pushDirection = (player.transform.position - transform.position).normalized;

        player.GetComponent<Rigidbody2D>().AddForce(pushDirection * pushForce, ForceMode2D.Impulse);

        animator.SetTrigger("Wind");

        // 효과음 재생
        audioSource.PlayOneShot(windSound);

        yield return new WaitForSeconds(2f);

        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        nextPattern = Random.Range(2, 4);
        yield return new WaitForSeconds(2f);
        nextPatternPlay();
    }

    IEnumerator punch()
    {
        animator.SetTrigger("Punch");

        // 효과음 재생
        audioSource.PlayOneShot(punchSound);

        nextPattern = Random.Range(1, 4);
        yield return new WaitForSeconds(2f);
        nextPatternPlay();
    }

    IEnumerator uppercut()
    {
        rb.AddForce(rb.transform.position);
        animator.SetTrigger("Uppercut");

        // 효과음 재생
        audioSource.PlayOneShot(uppercutSound);

        nextPattern = Random.Range(1, 4);
        yield return new WaitForSeconds(2f);
        nextPatternPlay();
    }

    IEnumerator moving()
    {
        animator.SetTrigger("Moving");

        // 효과음 재생
        audioSource.PlayOneShot(movingSound);

        nextPattern = Random.Range(1, 4);
        yield return new WaitForSeconds(2f);
        nextPatternPlay();
    }

    void nextPatternPlay()
    {
        switch (nextPattern)
        {
            case 1:
                StartCoroutine(wind());
                break;
            case 2:
                StartCoroutine(punch());
                break;
            case 3:
                StartCoroutine(uppercut());
                break;
            case 4:
                StartCoroutine(moving());
                break;
        }
    }
}
