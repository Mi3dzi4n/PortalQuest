using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;
    public float jumpHeight;
    bool grounded;
    public Vector2 BoxSize;
    public float castDistance;
    public LayerMask groundLayer;
    

    private Rigidbody2D rb; // Referencja do Rigidbody2D

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Pobierz komponent Rigidbody2D tylko raz

    }

 

    void FixedUpdate()
    { 

        // Sprawdzanie skoku, tylko je�li gracz jest na ziemi
        if (IsGrounded() && Input.GetKey(KeyCode.Space))
        {
            // Skok, zachowuj�c pr�dko�� w osi X
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpHeight);
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
    public bool IsGrounded()
    {
        if (Physics2D.BoxCast(transform.position, BoxSize, 0, -transform.up, castDistance, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, BoxSize);
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
