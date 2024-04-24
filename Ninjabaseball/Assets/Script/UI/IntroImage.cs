using UnityEngine;

public class IntroImage : MonoBehaviour
{
    public RectTransform introImage;
    public float duration = 2f;

    private Vector3 startPosition;
    private Vector3 targetPosition;

    private float currentTime = 0f;

    void Start()
    {
        startPosition = new Vector3(Screen.width, 0f, 0f); // ������ ȭ�� �ۿ��� ����
        targetPosition = Vector3.zero; // ȭ�� ����� �̵�
        introImage.localPosition = startPosition; // ���� ��ġ ����
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
