using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GoGo : MonoBehaviour
{
    float time;
    Image GOimage;
    // Start is called before the first frame update
    void Start()
    {
        GOimage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 0.5f)
        {
            GOimage.color = new Color(1, 1, 1, 1);
        }
        else
        {
            GOimage.color = new Color(1, 1, 1, 0);
        }
        if (time >= 1f)
        {
            time = 0f;
        }
    }
}
