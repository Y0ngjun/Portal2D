// ������ ����
using UnityEngine;

public class CustomPhysics : MonoBehaviour
{
    public float maxVelocityX;
    public float maxVelocityY;

    private Rigidbody2D rigidbody2d;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // �ִ� �̵��ӵ� ����
        if (Mathf.Abs(rigidbody2d.velocity.x) > maxVelocityX)
        {
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x / Mathf.Abs(rigidbody2d.velocity.x) * maxVelocityX, rigidbody2d.velocity.y);
        }
        if (Mathf.Abs(rigidbody2d.velocity.y) > maxVelocityY)
        {
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, rigidbody2d.velocity.y / Mathf.Abs(rigidbody2d.velocity.y) * maxVelocityY);
        }
    }
}
