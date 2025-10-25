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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (linkedPortal == null)
        {
            return;
        }

        GameObject other = collision.gameObject;

        Port(other);
    }

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
