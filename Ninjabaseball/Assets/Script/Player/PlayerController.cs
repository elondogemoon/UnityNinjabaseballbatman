using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpForce = 10.0f;
    public AudioSource playerdie;
    private Vector2 inputMovement = Vector2.zero;
    private BoxCollider2D boxcollider;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer; // Added SpriteRenderer variable
    private bool isDamaged;
    private bool isDead;
    public int MaxHp = 100;
    public int NowHp;
    
    // Start is called before the first frame update
    void Start()
    {
        boxcollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // Initialize SpriteRenderer
        NowHp = MaxHp;
        animator.SetTrigger("isStart");
    }

    void Update()
    {
        if (!isDead)
        {
            Vector2 moveMovement = inputMovement * moveSpeed * Time.deltaTime;
            transform.Translate(moveMovement);
        }
    }

    private void OnMove(InputValue inputValue)
    {
        
        inputMovement = inputValue.Get<Vector2>();
        if (inputMovement.x < 0)
        {
            transform.localScale = new Vector2(-1, 1);
            animator.SetBool("isRun", true);
        }
        else if (inputMovement.x > 0)
        {
            transform.localScale = new Vector2(1, 1);
            animator.SetBool("isRun", true);
        }
        else if (inputMovement.y < 0)
        {
            animator.SetBool("isRun", true);
        }
        else if (inputMovement.y > 0)
        {
            animator.SetBool("isRun", true);
        }
        else
        {
            animator.SetBool("isRun", false);
        }
    }

    private void OnJump(InputValue inputValue)
    {
        if (inputValue.isPressed)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            animator.SetBool("isJump", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("적이다");
            isDamaged = true;
            
        }
        if(collision.gameObject.tag == "Item")
        {
            Debug.Log("아이템이다");
        }
        if (collision.gameObject.tag == "GoldBat")
        {
            Debug.Log("황금빠따");
        }
    }
    public void TakeDamage(int damage)
    {
        if (!isDead)
        {
            NowHp -= damage;
            OnDamaged();
            if (NowHp <= 0)
            {
                Die();
            }
        }
    }
    void Die()
    {
        if(NowHp==0)
        isDead = true;
        Debug.Log("플레이어 컷");
        StartCoroutine(BlinkEffect());
        animator.SetBool("isDead", true);
        animator.SetTrigger("isDie");
        Invoke("Revival", 5);
    }
    void Revival()
    {
        isDead = false;
        animator.SetBool("isDead", false);
        NowHp = MaxHp;
    }
    public void OnDamaged()
    {
        animator.SetBool("isDamaged", true);

        // 플레이어 깜빡임 효과
        StartCoroutine(BlinkEffect());
    }

    private IEnumerator BlinkEffect()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

       
        float duration = 1f; 
        int blinkCount = 5; 
        float blinkInterval = duration / (blinkCount * 2);

        
        for (int i = 0; i < blinkCount; i++)
        {
            spriteRenderer.DOFade(0f, blinkInterval); 
            yield return new WaitForSeconds(blinkInterval);

            spriteRenderer.DOFade(1f, blinkInterval); 
            yield return new WaitForSeconds(blinkInterval);
        }

        
        OffDamaged();
    }

    private void OffDamaged()
    {
        animator.SetBool("isDamaged", false);
    }
    void DieSound()
    {
        playerdie.Play();
    }

}
