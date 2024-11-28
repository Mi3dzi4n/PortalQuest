using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class Movetest : MonoBehaviour
{
    public float moveSpeed = 40f;
    public float jumpHeight;
    public Vector2 BoxSize;
    public float castDistance;
    public LayerMask groundLayer;
    public LayerMask ladderLayer;
    public Animator animator;
    float horizontalMove = 0f;

    private Rigidbody2D rb; // Referencja do Rigidbody2D
    private bool IsLadder = false;
    private bool facingRight = true; // Czy posta� jest skierowana w prawo?

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Pobierz komponent Rigidbody2D
        animator = GetComponent<Animator>();
        animator.SetFloat("Speed", 0f); // Ustaw Speed na 0, aby rozpocz�� animacj� Idle
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
        horizontalMove = Input.GetAxisRaw("Horizontal"); // Odczyt ruchu na osi poziomej (-1, 0, 1)

        // Je�li oba klawisze s� wci�ni�te, zatrzymaj posta�
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }
        else if (horizontalMove != 0)
        {
            // Ruch w lewo lub prawo w zale�no�ci od warto�ci horizontalMove
            rb.linearVelocity = new Vector2(horizontalMove * moveSpeed, rb.linearVelocity.y);
        }
        else
        {
            // Je�li nic nie jest wci�ni�te, zatrzymaj posta�
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }

        // Animacja pr�dko�ci
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove * moveSpeed));

        // Obs�uga odwracania postaci
        FlipCharacter(horizontalMove);

        // Obs�uga skoku
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
        // Je�li posta� porusza si� w prawo i jest skierowana w lewo, lub odwrotnie, odwr�� j�
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
        facingRight = !facingRight; // Prze��cz kierunek postaci

        // Odwr�� posta� przez zmian� skali na osi X
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            IsLadder = true;
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

