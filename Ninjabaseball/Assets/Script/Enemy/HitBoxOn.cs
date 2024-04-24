using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxOn : MonoBehaviour
{
    Collider2D Collider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void ColliderOn()
    {
        gameObject.GetComponent<Collider2D>().enabled = true;
        Debug.Log("Ä×´Ù");
    }
    void ColliderOff()
    {
        gameObject.GetComponent<Collider2D>().enabled = false;
        Debug.Log("²°´Ù");
    }
}
