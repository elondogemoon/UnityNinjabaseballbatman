using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Boss_Hp_bar : MonoBehaviour
{
    [SerializeField] private Image hpbar;
    [SerializeField] private EnemyEx enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = FindObjectOfType<EnemyEx>();

    }

    // Update is called once per frame
    void Update()
    {
        UpdateHpBar();
    }
    private void UpdateHpBar()
    {
        float maxHp = enemy.maxHp;
        float currenHp = enemy.currentHp;
        if(maxHp != 0)
        {
            hpbar.fillAmount = currenHp/maxHp;
        }
    }
}
