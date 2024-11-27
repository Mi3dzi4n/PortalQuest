using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 40f;
    public float jumpHeight;
    public Vector2 BoxSize;
    public float castDistance;
    public LayerMask groundLayer;
    public Animator animator;
    float horizontalMove = 0f;

    private Rigidbody2D rb; // Referencja do Rigidbody2D

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Pobierz komponent Rigidbody2D
        animator = GetComponent<Animator>();
        animator.SetFloat("Speed", 0f); // Ustaw Speed na 0, aby rozpocz�� animacj� Idle
    }



    [SerializeField]
    public bool IsGrounded()
    {
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
        horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove)); // Zmieniaj animator w Update
        FlipCharacter(horizontalMove);

        horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;

        FlipCharacter(horizontalMove);


        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        // Sprawdzanie skoku, tylko je�li gracz jest na ziemi
        if (IsGrounded() && Input.GetKey(KeyCode.Space))
        {
            // Skok, zachowuj�c pr�dko�� w osi X
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpHeight);
            animator.SetBool("IsJumping", true);
        }

        // Ruch w prawo (po naci�ni�ciu klawisza D)
        if (Input.GetKey(KeyCode.D))
        {
            // Zmiana pr�dko�ci w osi X, zachowuj�c pr�dko�� w osi Y
            rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
        }
        // Ruch w lewo (po naci�ni�ciu klawisza A)
        else if (Input.GetKey(KeyCode.A))
        {
            // Zmiana pr�dko�ci w osi X, zachowuj�c pr�dko�� w osi Y
            rb.linearVelocity = new Vector2(-moveSpeed, rb.linearVelocity.y);
        }
        else
        {
            // Je�li �aden klawisz nie jest wci�ni�ty, zatrzymaj ruch w poziomie
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);

        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, BoxSize);
    }

    private bool facingRight = true; // Czy posta� jest skierowana w prawo?

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

    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (other.gameObject.CompareTag("Ground"))
    //    {

    //        {
    //            grounded = true;
    //        }

    //    }
    //}
    //private void OnCollisionExit2D(Collision2D other)
    //{
    //    if (other.gameObject.CompareTag("Ground"))
    //    {
    //        grounded = false;
    //    }
    //}   
}