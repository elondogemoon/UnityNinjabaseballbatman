using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_Bar : MonoBehaviour
{
    [SerializeField] private Image hpBar;
    [SerializeField] private PlayerController playerController;

    private void Start()
    {
        
        playerController = FindObjectOfType<PlayerController>();

        
        if (playerController == null)
        {
            Debug.LogError("플레이어 컨트롤러를 찾을 수 없습니다.");
        }
    }

    private void Update()
    {
        
        UpdateHPBar();
    }

    private void UpdateHPBar()
    {
        
        float maxHp = playerController.MaxHp;
        float currentHp = playerController.NowHp;

        
        if (maxHp != 0)
        {
            hpBar.fillAmount = currentHp / maxHp;
        }
        else
        {
            Debug.LogError("플레이어의 최대 체력이 0입니다.");
        }
    }
    private void UpdateImage()
    {
        gameObject.SetActive(true);
    }
}
