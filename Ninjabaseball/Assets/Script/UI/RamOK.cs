using UnityEngine;
using UnityEngine.SceneManagement;


public class RamOK : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        // Animator 컴포넌트 가져오기
        animator = GetComponent<Animator>();

        // 애니메이션 재생
        
    }
    void OnAnimationFinish()
    {
        SceneManager.LoadScene("Intro");
    }
}
