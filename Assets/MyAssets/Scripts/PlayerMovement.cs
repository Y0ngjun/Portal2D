using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerInput playerInput;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float moveSpeed;
    public float jumpForce;
    public float checkRadius;
    public float maxVelocityX;
    public float maxVelocityY;

    private Rigidbody2D rigidbody2d;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool isGrounded;
    private bool isShooting;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        isGrounded = false;
        isShooting = false;
    }

    void Update()
    {
        if (Mathf.Abs(rigidbody2d.velocity.x) > maxVelocityX)
        {
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x / Mathf.Abs(rigidbody2d.velocity.x) * maxVelocityX, rigidbody2d.velocity.y);
        }
        if (Mathf.Abs(rigidbody2d.velocity.y) > maxVelocityY)
        {
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, rigidbody2d.velocity.y / Mathf.Abs(rigidbody2d.velocity.y) * maxVelocityY);
        }
    }

    private void FixedUpdate()
    {
        if (gameManager == null || gameManager.isGameOver || playerInput == null)
        {
            return;
        }

        IsGrounded();
        Movement();
    }

    private void IsGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        animator.SetBool("Ground", isGrounded);
    }

    private void Movement()
    {
        rigidbody2d.velocity = new Vector2(playerInput.move * moveSpeed, rigidbody2d.velocity.y);

        if (playerInput.move != 0)
        {
            animator.SetBool("Run", true);

            if (!isShooting)
            {
                if (playerInput.move > 0)
                {
                    spriteRenderer.flipX = false;
                }
                else if (playerInput.move < 0)
                {
                    spriteRenderer.flipX = true;
                }
            }
        }
        else
        {
            animator.SetBool("Run", false);
        }

        if (playerInput.jump && isGrounded)
        {
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, 0);
            rigidbody2d.AddForce(new Vector2(0, jumpForce));

            animator.SetTrigger("Jump");
            animator.SetBool("Ground", false);
        }
    }

    public void SetShootingState(bool shooting)
    {
        isShooting = shooting;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }
}
