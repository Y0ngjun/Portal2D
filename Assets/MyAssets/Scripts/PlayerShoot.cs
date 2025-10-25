using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerInput playerInput;
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
        }
    }
}
