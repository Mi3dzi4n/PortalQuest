using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;
    public float jumpHeight;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask Ground;
    [SerializeField] private bool grounded;

    private Rigidbody2D rb; // Referencja do Rigidbody2D

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Pobierz komponent Rigidbody2D tylko raz
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, Ground); // Sprawd�, czy gracz jest na ziemi
    }

    void Update()
    {
        // Sprawdzanie skoku, tylko je�li gracz jest na ziemi
        if (grounded && Input.GetKey(KeyCode.Space))
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
}
