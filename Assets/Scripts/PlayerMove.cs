using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 40f;
    public float jumpHeight;
    public Vector2 BoxSize;
    public float castDistance;
    public LayerMask groundLayer;
    public LayerMask ladderLayer;
    public Animator animator;
    private float horizontalMove = 0f;
    private float vertical;
    private Rigidbody2D rb;
    private bool IsLadder = false;
    private bool facingRight = true;
    private bool doubleJump;
    private bool isFalling;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetFloat("Speed", 0f);
    }

    [SerializeField]
    public bool IsGrounded()
    {
        if (IsLadder)
        {
            animator.SetBool("IsClimbing", true);
            animator.SetBool("IsJumping", false);
            return false;
        }

        bool grounded = Physics2D.BoxCast(transform.position, BoxSize, 0, -transform.up, castDistance, groundLayer);
        animator.SetBool("IsJumping", !grounded);

        if (grounded)
        {
            doubleJump = false;
            animator.SetBool("isDoubleJumping", false);
            isFalling = false;
        }
        else if (rb.linearVelocity.y < 0)
        {
            isFalling = true;
        }
        return grounded;
    }

    void Update()
    {
        IsGrounded();
        vertical = Input.GetAxis("Vertical");

        if (IsLadder && Mathf.Abs(vertical) > 0f)
        {
            animator.SetBool("IsClimbing", true);
        }
        else
        {
            animator.SetBool("IsClimbing", false);
        }

        horizontalMove = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(horizontalMove * moveSpeed, rb.linearVelocity.y);
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove * moveSpeed));
        FlipCharacter(horizontalMove);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded())
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpHeight);
            }
            else if (!IsGrounded() && !doubleJump)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpHeight - 2);
                doubleJump = true;
                animator.SetBool("isDoubleJumping", true);
            }
            else if (isFalling && !doubleJump) // Wykrycie swobodnego spadku
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpHeight - 2);
                doubleJump = true;
                animator.SetBool("isDoubleJumping", true);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, BoxSize);
    }

    private void FlipCharacter(float horizontal)
    {
        if (horizontal > 0 && !facingRight)
        {
            Flip();
        }
        else if (horizontal < 0 && facingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            IsLadder = true;
            animator.SetBool("IsClimbing", true);
            animator.SetBool("IsJumping", false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            IsLadder = false;
            animator.SetBool("IsClimbing", false);
        }
    }
}
