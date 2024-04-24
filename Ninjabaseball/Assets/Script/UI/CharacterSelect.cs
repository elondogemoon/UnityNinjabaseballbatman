using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    public Transform[] characterPositions; // 캐릭터 위치 배열
    public GameObject selector; // 선택 표시기(예: 화살표)
    
    private int currentIndex = 0;

    private void Start()
    {
        // 초기 캐릭터 선택 위치로 이동
        MoveSelectorToPosition(currentIndex);
    }

    private void Update()
    {
        // 좌우 화살표 키 입력 감지
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveSelector(-1); // 왼쪽으로 이동
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveSelector(1); // 오른쪽으로 이동
        }
    }

    private void MoveSelector(int direction)
    {
        currentIndex = Mathf.Clamp(currentIndex + direction, 0, characterPositions.Length - 1);
        MoveSelectorToPosition(currentIndex);
    }

    private void MoveSelectorToPosition(int index)
    {
        // 선택 표시기(selector)를 해당 위치로 이동
        selector.transform.position = characterPositions[index].position;
    }
    
    
}
