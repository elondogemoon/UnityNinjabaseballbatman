using UnityEngine;

public class BlinkObject : MonoBehaviour
{
    public float blinkInterval = 2f; // 깜빡임 초기 간격 (초)
    public float duration = 5f; // 사라질 때까지의 시간
    public float blinkSpeedIncrease = 0.01f; // 깜빡임 속도 증가량

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
        // 시간 측정
        timer += Time.deltaTime;

        // 깜빡임 효과
        if (timer >= blinkSpeed)
        {
            isVisible = !isVisible;
            spriteRenderer.enabled = isVisible;
            

            // 깜빡임 간격 감소
            blinkSpeed -= blinkSpeedIncrease;
            blinkSpeed = Mathf.Max(blinkSpeed, 0.05f); // 최소 간격 설정
        }
        
        // 사라짐
        if (timer >= duration)
        {
            Destroy(gameObject);
        }
    }
}
