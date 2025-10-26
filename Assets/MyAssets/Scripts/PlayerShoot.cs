// Æ÷Å» °Ç ·ÎÁ÷
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerInput playerInput;
    public GameObject bulletPrefab1;
    public GameObject bulletPrefab2;
    public float shootTime;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private float lastShootTime;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        lastShootTime = Time.time - shootTime;
    }

    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (playerInput.shoot1 && Time.time > lastShootTime + shootTime)
        {
            lastShootTime = Time.time;

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (mousePos.x > transform.position.x)
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
            }

            animator.SetTrigger("Shoot");

            //if (GameManager.Instance.portal1 != null)
            //{
            //    Destroy(GameManager.Instance.portal1);
            //}

            GameObject go = Instantiate(bulletPrefab1, transform.position, Quaternion.identity);
            go.GetComponent<Bullet>().SetBulletType(1);
        }
        if (playerInput.shoot2 && Time.time > lastShootTime + shootTime)
        {
            lastShootTime = Time.time;

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (mousePos.x > transform.position.x)
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
            }

            animator.SetTrigger("Shoot");

            //if (GameManager.Instance.portal2 != null)
            //{
            //    Destroy(GameManager.Instance.portal2);
            //}

            GameObject go = Instantiate(bulletPrefab2, transform.position, Quaternion.identity);
            go.GetComponent<Bullet>().SetBulletType(2);
        }
    }
}
