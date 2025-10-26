// 포탈 로직
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Portal linkedPortal;

    void Start()
    {

    }

    void Update()
    {

    }

    // 포탈 진입점
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (linkedPortal == null)
        {
            return;
        }

        GameObject other = collision.gameObject;

        Port(other);
    }

    // 플레이어를 연결된 포탈로 이동
    private void Port(GameObject gameObject)
    {
        Rigidbody2D rigidbody2d = gameObject.GetComponent<Rigidbody2D>();

        if (rigidbody2d == null)
        {
            return;
        }
        Quaternion rotation = Quaternion.FromToRotation(transform.right, -linkedPortal.transform.right);
        Vector2 velocity = rotation * rigidbody2d.velocity;

        gameObject.transform.position = linkedPortal.transform.position - linkedPortal.transform.right * 1.5f;
        rigidbody2d.velocity = velocity;
    }
}
