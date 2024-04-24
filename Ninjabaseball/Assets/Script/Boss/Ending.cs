using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    public GameObject goldbat;
    public EnemyEx enemyEx;
    public Player player;
    public Animator Animator;
    void Start()
    {
        // enemyEx 객체를 초기화합니다.
        enemyEx = FindObjectOfType<EnemyEx>();
    }

    void Update()
    {
        // enemyEx가 null이 아닌 경우에만 실행합니다.
        if (enemyEx != null)
        {
           

            // 적의 체력이 20 이하일 때 ShowBat() 메서드를 호출합니다.
            if (enemyEx.currentHp <= 0)
            {
                ShowBat();
                PlayEndingPose();
            }
        }
    }

    void ShowBat()
    {
        // goldbat을 적의 위치에 보이도록 설정합니다.
        goldbat.transform.position = enemyEx.transform.position;
        goldbat.SetActive(true);
        Invoke("PlayEndingPose", 3);
    }

    
    void PlayEndingPose()
    {
        Animator.SetTrigger("isWin");
        Invoke("EndingCredit", 8);
    }
    void EndingCredit()
    {
        SceneManager.LoadScene("Ending");
    }
}
