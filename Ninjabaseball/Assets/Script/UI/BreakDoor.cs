using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BreakDoor : MonoBehaviour
{
    public int hp = 100;
    int currenthp;
    Collider2D collider2D;
    public AudioSource AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        collider2D = GetComponent<Collider2D>();
        currenthp = hp;
    }
    public void TakeDamage(int damage)
    {
        AudioSource.Play();
        transform.DOShakePosition(1,1,10,1,false,true);
        transform.DOShakePosition(1, new Vector2(0, 1), 10, 1, false, true);
        currenthp -= damage;
        if (currenthp <= 0)
        {
            collider2D.enabled = false;
            
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>();
        }
    }
}
