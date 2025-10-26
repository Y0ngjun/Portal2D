using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject portalPrefab;
    public float speed;

    private Rigidbody2D rigidbody2d;
    private Vector2 bulletDirection;
    private int bulletType;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        bulletDirection = (Vector2)mouseWorldPos - (Vector2)transform.position;
        float angle = Mathf.Atan2(bulletDirection.y, bulletDirection.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);
        rigidbody2d.velocity = transform.right * speed;
    }

    void Update()
    {

    }

    public void SetBulletType(int type)
    {
        bulletType = type;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Portable"))
        {
            ContactPoint2D contact = collision.contacts[0];
            Vector2 normal = contact.normal;

            // 노멀 벡터가 뒤집히는 현상 해결
            float dot = Vector2.Dot(bulletDirection, normal);
            if (dot > 0)
            {
                normal = -normal;
            }

            Vector2 position = contact.point;
            Vector2 direction = -normal;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0, 0, angle);

            GameObject go = Instantiate(portalPrefab, position, rotation);

            if (bulletType == 1)
            {
                GameManager.Instance.SetPortal1(go);
            }
            else if (bulletType == 2)
            {
                GameManager.Instance.SetPortal2(go);
            }
        }

        if (!collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
