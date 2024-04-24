using UnityEngine;

public class BlinkObject : MonoBehaviour
{
    public float blinkInterval = 2f; // ������ �ʱ� ���� (��)
    public float duration = 5f; // ����� �������� �ð�
    public float blinkSpeedIncrease = 0.01f; // ������ �ӵ� ������

    private SpriteRenderer spriteRenderer;
    private float timer;
    private float blinkSpeed;
    private bool isVisible = true;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        timer = 0f;
        blinkSpeed = blinkInterval;
    }

    private void Update()
    {
        // �ð� ����
        timer += Time.deltaTime;

        // ������ ȿ��
        if (timer >= blinkSpeed)
        {
            isVisible = !isVisible;
            spriteRenderer.enabled = isVisible;
            

            // ������ ���� ����
            blinkSpeed -= blinkSpeedIncrease;
            blinkSpeed = Mathf.Max(blinkSpeed, 0.05f); // �ּ� ���� ����
        }
        
        // �����
        if (timer >= duration)
        {
            Destroy(gameObject);
        }
    }
}
