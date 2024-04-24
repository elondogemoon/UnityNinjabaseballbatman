using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float cameraSpeed = 5.0f;
    public GameObject player;

    void Update()
    {
        // 플레이어와 카메라의 위치 차이를 계산
        Vector2 dir = player.transform.position - this.transform.position;

        // x 축으로만 이동하는 벡터 생성
        Vector2 moveVector = new Vector2(dir.x * cameraSpeed * Time.deltaTime, 0);

        // 카메라 이동
        this.transform.Translate(moveVector);

        // 카메라의 x 좌표를 제한하여 화면 내에 유지
        Vector3 worldpos = Camera.main.WorldToViewportPoint(this.transform.position);
        worldpos.x = Mathf.Clamp01(worldpos.x);

        // 카메라의 y 좌표를 고정
        worldpos.y = 0.5f; // 또는 다른 값을 원하는 위치에 따라 수정

        // 카메라의 위치를 월드 좌표로 변환하여 설정
        this.transform.position = Camera.main.ViewportToWorldPoint(worldpos);
    }
}
