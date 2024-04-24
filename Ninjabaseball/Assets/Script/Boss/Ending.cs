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
        // enemyEx ��ü�� �ʱ�ȭ�մϴ�.
        enemyEx = FindObjectOfType<EnemyEx>();
    }

    void Update()
    {
        // enemyEx�� null�� �ƴ� ��쿡�� �����մϴ�.
        if (enemyEx != null)
        {
           

            // ���� ü���� 20 ������ �� ShowBat() �޼��带 ȣ���մϴ�.
            if (enemyEx.currentHp <= 0)
            {
                ShowBat();
                PlayEndingPose();
            }
        }
    }

    void ShowBat()
    {
        // goldbat�� ���� ��ġ�� ���̵��� �����մϴ�.
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
