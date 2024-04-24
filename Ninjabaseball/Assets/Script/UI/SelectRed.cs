using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectRed : MonoBehaviour
{
    public GameObject redCharacter; // 레드 캐릭터 게임 오브젝트
    public AudioSource redAudioSource;
    public AudioClip redClip;

    private void Start()
    {
       
        redAudioSource = GetComponent<AudioSource>();
        redClip = GetComponent<AudioClip>();
    }

    // Update is called once per frame
    void Update()
    {
        // z 키 입력을 감지하여 레드 캐릭터 활성화
        if (Input.GetKeyDown(KeyCode.Z))
        {
            redCharacter.SetActive(true);
            if (redAudioSource != null && redClip != null)
            {
                redAudioSource.Play();
            }
            Invoke("StartGame", 3f);
        }

    }

    void StartGame()
    {
        SceneManager.LoadScene("Stage1-1");
    }
}
