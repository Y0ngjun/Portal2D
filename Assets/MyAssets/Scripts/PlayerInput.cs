// 입력 관리
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float move;
    public bool jump;
    public bool down;
    public bool shoot1;
    public bool shoot2;

    void Start()
    {
        move = 0;
        jump = false;
        down = false;
    }

    void Update()
    {
        if (GameManager.Instance == null || GameManager.Instance.isGameOver)
        {
            move = 0;
            jump = false;
            down = false;
            return;
        }

        move = Input.GetAxisRaw("Horizontal");
        jump = Input.GetKey(KeyCode.W);
        down = Input.GetKey(KeyCode.S);
        shoot1 = Input.GetMouseButton(0);
        shoot2 = Input.GetMouseButton(1);
    }
}
