using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    //일정한 간격을 두고 계속 스폰할 프리팹
    public GameObject prefabToSpawn;
    public float repeatInterval;
    
    // Start is called before the first frame update
    public void Start()
    {
        if (repeatInterval > 0)
        {
            InvokeRepeating("SpawnObject",0.0f,repeatInterval);
        }
    }
    public GameObject SpawnObject()
    {
        if(prefabToSpawn != null)
        {
            return Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
        }
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
