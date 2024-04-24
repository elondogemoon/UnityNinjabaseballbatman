using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    public Transform[] characterPositions; // ĳ���� ��ġ �迭
    public GameObject selector; // ���� ǥ�ñ�(��: ȭ��ǥ)
    
    private int currentIndex = 0;

    private void Start()
    {
        // �ʱ� ĳ���� ���� ��ġ�� �̵�
        MoveSelectorToPosition(currentIndex);
    }

    private void Update()
    {
        // �¿� ȭ��ǥ Ű �Է� ����
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveSelector(-1); // �������� �̵�
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveSelector(1); // ���������� �̵�
        }
    }

    private void MoveSelector(int direction)
    {
        currentIndex = Mathf.Clamp(currentIndex + direction, 0, characterPositions.Length - 1);
        MoveSelectorToPosition(currentIndex);
    }

    private void MoveSelectorToPosition(int index)
    {
        // ���� ǥ�ñ�(selector)�� �ش� ��ġ�� �̵�
        selector.transform.position = characterPositions[index].position;
    }
    
    
}
