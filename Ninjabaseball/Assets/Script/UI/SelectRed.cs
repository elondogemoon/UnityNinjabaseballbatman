using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectRed : MonoBehaviour
{
    public GameObject redCharacter; // ���� ĳ���� ���� ������Ʈ
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
        // z Ű �Է��� �����Ͽ� ���� ĳ���� Ȱ��ȭ
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
