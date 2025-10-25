using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public GameManager gameManager;
    public float move;
    public bool jump;
    public bool down;
    public bool shoot1;

    void Start()
    {
        move = 0;
        jump = false;
        down = false;
    }

    void Update()
    {
        if (gameManager == null || gameManager.isGameOver)
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
    }
}
