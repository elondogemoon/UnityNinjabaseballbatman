using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject item;
    public GameObject LifeUpUi;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>(); 
            if (playerController != null) // 
            {
                HpUp(playerController);
            }
            Destroy(item);
            LifeUpUi.SetActive(true);
            
            Invoke("DisableText", 3);
        }
    }
    
    public void HpUp(PlayerController playerController)
    {
        if (playerController.NowHp > 0)
        {
            playerController.NowHp += 10;
            if (playerController.NowHp >= 100)
            {
                playerController.NowHp = 100;
            }
        }
    }
    public void DisableText()
    {
        Debug.Log("3초후 삭제");
        Destroy(LifeUpUi);
    }
}
