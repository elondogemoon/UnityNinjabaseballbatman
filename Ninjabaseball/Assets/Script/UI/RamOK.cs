using UnityEngine;
using UnityEngine.SceneManagement;


public class RamOK : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        // Animator ������Ʈ ��������
        animator = GetComponent<Animator>();

        // �ִϸ��̼� ���
        
    }
    void OnAnimationFinish()
    {
        SceneManager.LoadScene("Intro");
    }
}
