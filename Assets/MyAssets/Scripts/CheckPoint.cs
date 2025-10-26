// 체크 포인트
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            LevelManager.Instance.NextStep();
        }
    }
}
