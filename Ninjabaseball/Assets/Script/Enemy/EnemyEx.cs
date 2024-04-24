using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class EnemyEx : MonoBehaviour
{
    public Transform pos;
    public Animator animator;
    public int maxHp = 100;
    public int currentHp;
    public int damage = 2;
    PlayerController playerController;
    public float cooltime;
    public float currenttime;
    public BoxCollider2D box;
    
    public AudioSource audioSource;
     void Start()
    {
        playerController = GetComponent<PlayerController>();
        currentHp = maxHp;
    }
    
    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        animator.SetTrigger("Hurt");
        audioSource.Play();
        if(currentHp <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        
        Debug.Log("ав╬Н╤С");
        animator.SetBool("isDead", true);
        box.enabled = false;
        
        StartCoroutine(DestroyAfterDelay(2f));
        
    }

    IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
    
}
