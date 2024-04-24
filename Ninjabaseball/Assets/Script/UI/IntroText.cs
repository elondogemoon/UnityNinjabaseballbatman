using UnityEngine;

public class IntroText : MonoBehaviour
{
    public RectTransform introImage;
    public float duration = 2f;

    private Vector3 startPosition;
    private Vector3 targetPosition;

    private float currentTime = 0f;

    void Start()
    {
        startPosition = introImage.localPosition;
        targetPosition = Vector3.zero; // 화면 가운데로 이동
    }

    void Update()
    {
        if (currentTime < duration)
        {
            float t = currentTime / duration;

            // 애니메이션을 위해 보간된 위치 계산
            Vector3 newPosition = Vector3.Lerp(startPosition, targetPosition, t);

            // UI 요소의 위치 설정
            introImage.localPosition = newPosition;

            currentTime += Time.deltaTime;
        }
        else
        {
            // 애니메이션 종료 후 필요한 작업을 수행
            // 예: 다음 씬으로 이동
        }
    }
}
