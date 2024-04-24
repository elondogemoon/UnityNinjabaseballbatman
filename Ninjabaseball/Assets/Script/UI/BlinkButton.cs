using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BlinkButton : MonoBehaviour
{
    float time;
    Image buttonImage;

    // Start is called before the first frame update
    void Start()
    {
        buttonImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 0.5f)
        {
            buttonImage.color = new Color(1, 1, 1, 1);
        }
        else
        {
            buttonImage.color = new Color(1, 1, 1, 0);
        }
        if (time >= 1f)
        {
            time = 0;
        }

        // 사용자 입력 감지
        if (Input.anyKeyDown)
        {
            // 다음 씬으로 이동
            SceneManager.LoadScene("CharacterSelect");
        }
    }
}
