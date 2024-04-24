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
        targetPosition = Vector3.zero; // ȭ�� ����� �̵�
    }

    void Update()
    {
        if (currentTime < duration)
        {
            float t = currentTime / duration;

            // �ִϸ��̼��� ���� ������ ��ġ ���
            Vector3 newPosition = Vector3.Lerp(startPosition, targetPosition, t);

            // UI ����� ��ġ ����
            introImage.localPosition = newPosition;

            currentTime += Time.deltaTime;
        }
        else
        {
            // �ִϸ��̼� ���� �� �ʿ��� �۾��� ����
            // ��: ���� ������ �̵�
        }
    }
}
