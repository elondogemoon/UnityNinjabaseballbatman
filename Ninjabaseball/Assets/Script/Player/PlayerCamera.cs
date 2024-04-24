using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float cameraSpeed = 5.0f;
    public GameObject player;

    void Update()
    {
        // �÷��̾�� ī�޶��� ��ġ ���̸� ���
        Vector2 dir = player.transform.position - this.transform.position;

        // x �����θ� �̵��ϴ� ���� ����
        Vector2 moveVector = new Vector2(dir.x * cameraSpeed * Time.deltaTime, 0);

        // ī�޶� �̵�
        this.transform.Translate(moveVector);

        // ī�޶��� x ��ǥ�� �����Ͽ� ȭ�� ���� ����
        Vector3 worldpos = Camera.main.WorldToViewportPoint(this.transform.position);
        worldpos.x = Mathf.Clamp01(worldpos.x);

        // ī�޶��� y ��ǥ�� ����
        worldpos.y = 0.5f; // �Ǵ� �ٸ� ���� ���ϴ� ��ġ�� ���� ����

        // ī�޶��� ��ġ�� ���� ��ǥ�� ��ȯ�Ͽ� ����
        this.transform.position = Camera.main.ViewportToWorldPoint(worldpos);
    }
}
