using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerMove playerMove; // Reference to the PlayerMove script
    private bool canDoubleJump;

    public float doubleJumpHeight = 15f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerMove = GetComponent<PlayerMove>();
    }

    void Update()
    {
        // Check if the player is grounded from the PlayerMove script
        if (playerMove.IsGrounded())
        {
            canDoubleJump = true; // Reset double jump when grounded
        }

        // Handle double jump
        if (!playerMove.IsGrounded() && canDoubleJump && Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, doubleJumpHeight);
            canDoubleJump = false; // Prevent further jumps until grounded
            playerMove.animator.SetBool("IsJumping", true); // Update animation
        }
    }
}
