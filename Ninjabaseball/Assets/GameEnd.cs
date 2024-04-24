using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    public Animator playerAnimator; // 플레이어의 애니메이터 컴포넌트
    //public string nextSceneName; // 다음 씬의 이름

    private void Start()
    {
       
        playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    // 적이 죽었을 때 호출되는 메서드
    public void Ending()
    {
       
        playerAnimator.SetTrigger("isWin");

        // 일정 시간 후 다음 씬으로 이동
        StartCoroutine(LoadNextSceneAfterDelay(3f));
    }

    // 일정 시간 후 다음 씬으로 이동하는 코루틴 메서드
    IEnumerator LoadNextSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        //SceneManager.LoadScene(nextSceneName);
    }
}
