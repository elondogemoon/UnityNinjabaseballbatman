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
            Debug.LogError("�÷��̾� ��Ʈ�ѷ��� ã�� �� �����ϴ�.");
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
            Debug.LogError("�÷��̾��� �ִ� ü���� 0�Դϴ�.");
        }
    }
    private void UpdateImage()
    {
        gameObject.SetActive(true);
    }
}
