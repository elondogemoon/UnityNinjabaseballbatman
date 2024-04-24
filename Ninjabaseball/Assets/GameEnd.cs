using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    public Animator playerAnimator; // �÷��̾��� �ִϸ����� ������Ʈ
    //public string nextSceneName; // ���� ���� �̸�

    private void Start()
    {
       
        playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    // ���� �׾��� �� ȣ��Ǵ� �޼���
    public void Ending()
    {
       
        playerAnimator.SetTrigger("isWin");

        // ���� �ð� �� ���� ������ �̵�
        StartCoroutine(LoadNextSceneAfterDelay(3f));
    }

    // ���� �ð� �� ���� ������ �̵��ϴ� �ڷ�ƾ �޼���
    IEnumerator LoadNextSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        //SceneManager.LoadScene(nextSceneName);
    }
}
