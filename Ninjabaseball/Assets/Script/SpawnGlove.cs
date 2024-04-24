using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGlove : MonoBehaviour
{
    // Start is called before the first frame update
    Collider2D collider;
    private void Start()
    {
        collider = GetComponent<Collider2D>();

    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("µµÂø");
    }
}
