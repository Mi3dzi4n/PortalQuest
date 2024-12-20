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
    float horizontalMove = 0f;
    private float vertical;
    private Rigidbody2D rb;
    private bool IsLadder = false;
    private bool facingRight = true;
    private bool doubleJump;

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
            animator.SetBool("IsJumping", false);
            return false;
        }

        if (Physics2D.BoxCast(transform.position, BoxSize, 0, -transform.up, castDistance, groundLayer))
        {
            animator.SetBool("IsJumping", false);
            return true;
        }
        else
        {
            return false;
        }
    }

    void Update()
    {
        if (IsGrounded())
        {
            doubleJump = false;
            animator.SetBool("isDoubleJumping", false); // Wyłączenie double jumpa po lądowaniu
        }

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

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }
        else if (horizontalMove != 0)
        {
            rb.linearVelocity = new Vector2(horizontalMove * moveSpeed, rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove * moveSpeed));

        FlipCharacter(horizontalMove);

        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("IsJumping", true);
        }
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space) && !doubleJump)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpHeight);
        }

        if (!IsGrounded() && Input.GetKeyDown(KeyCode.Space) && !doubleJump)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpHeight - 2);
            doubleJump = true;
            animator.SetBool("isDoubleJumping", true); // Włączenie animacji double jump
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
            animator.SetBool("IsJumping", false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            IsLadder = false;
        }
    }
}
