using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Rigidbody2D rb;
    private Camera mainCamera;
    private float minX, maxX, minY, maxY;
    private float playerWidth, playerHeight;
    private Vector3 previousPosition;
    private SpriteRenderer spriteRenderer;
    public float followSpeed = 5f; // ī�޶� �÷��̾ ����ٴ� �ӵ�

    void Start()
    {
        Player player = GetComponent<Player>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;

        // �÷��̾��� ũ�⸦ ������
        playerWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        playerHeight = GetComponent<SpriteRenderer>().bounds.size.y;

        // ī�޶��� ��踦 ���
        float camDistance = Vector3.Distance(transform.position, mainCamera.transform.position);
        Vector2 bottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        Vector2 topRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, camDistance));

        // �÷��̾ ī�޶� ��踦 �Ѿ�� ���ϵ��� ����
        minX = bottomLeft.x + playerWidth / 2;
        maxX = topRight.x - playerWidth / 2;
        minY = bottomLeft.y + playerHeight / 2;
        maxY = topRight.y - playerHeight / 2;

        // ���� ��ġ�� ���� ��ġ�� �ʱ�ȭ
        previousPosition = transform.position;
    }

    void Update()
    {
        // �÷��̾��� ��ġ�� ����
        Vector2 clampedPosition = new Vector2(
            Mathf.Clamp(transform.position.x, minX, maxX),
            Mathf.Clamp(transform.position.y, minY, maxY)
        );
        transform.position = clampedPosition;

        // �÷��̾ x������ �̵��� ������ ī�޶� ���� �̵��Ͽ� �÷��̾ ����ٴ�
        Vector3 moveDelta = transform.position - previousPosition;
        mainCamera.transform.position += moveDelta;
        previousPosition = transform.position;
    }
}
