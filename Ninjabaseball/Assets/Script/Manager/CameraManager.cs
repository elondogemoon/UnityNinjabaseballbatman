using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Rigidbody2D rb;
    private Camera mainCamera;
    private float minX, maxX, minY, maxY;
    private float playerWidth, playerHeight;
    private Vector3 previousPosition;
    private SpriteRenderer spriteRenderer;
    public float followSpeed = 5f; // 카메라가 플레이어를 따라다닐 속도

    void Start()
    {
        Player player = GetComponent<Player>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;

        // 플레이어의 크기를 가져옴
        playerWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        playerHeight = GetComponent<SpriteRenderer>().bounds.size.y;

        // 카메라의 경계를 계산
        float camDistance = Vector3.Distance(transform.position, mainCamera.transform.position);
        Vector2 bottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        Vector2 topRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, camDistance));

        // 플레이어가 카메라 경계를 넘어가지 못하도록 설정
        minX = bottomLeft.x + playerWidth / 2;
        maxX = topRight.x - playerWidth / 2;
        minY = bottomLeft.y + playerHeight / 2;
        maxY = topRight.y - playerHeight / 2;

        // 이전 위치를 현재 위치로 초기화
        previousPosition = transform.position;
    }

    void Update()
    {
        // 플레이어의 위치를 제한
        Vector2 clampedPosition = new Vector2(
            Mathf.Clamp(transform.position.x, minX, maxX),
            Mathf.Clamp(transform.position.y, minY, maxY)
        );
        transform.position = clampedPosition;

        // 플레이어가 x축으로 이동할 때마다 카메라도 같이 이동하여 플레이어를 따라다님
        Vector3 moveDelta = transform.position - previousPosition;
        mainCamera.transform.position += moveDelta;
        previousPosition = transform.position;
    }
}
