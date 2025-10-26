// 플레이어 이동 관리
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
        
    }

    // 물리 업데이트
    private void FixedUpdate()
    {
        if (gameManager == null || gameManager.isGameOver || playerInput == null)
        {
            return;
        }

        IsGrounded();
        Movement();
    }

    // 땅에 닿았는지 판별
    private void IsGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        animator.SetBool("Ground", isGrounded);
    }

    // 이동 및 점프
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
