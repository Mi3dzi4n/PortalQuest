using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

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

      
        if (IsGrounded() && Input.GetKey(KeyCode.Space))
        {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpHeight);
                animator.SetBool("IsJumping", true);          
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

