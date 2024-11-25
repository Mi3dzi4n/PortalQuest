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
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, Ground); // SprawdŸ, czy gracz jest na ziemi
    }

    void Update()
    {
        // Sprawdzanie skoku, tylko jeœli gracz jest na ziemi
        if (grounded && Input.GetKey(KeyCode.Space))
        {
            // Skok, zachowuj¹c prêdkoœæ w osi X
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpHeight);
        }

        // Ruch w prawo (po naciœniêciu klawisza D)
        if (Input.GetKey(KeyCode.D))
        {
            // Zmiana prêdkoœci w osi X, zachowuj¹c prêdkoœæ w osi Y
            rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
        }
        // Ruch w lewo (po naciœniêciu klawisza A)
        else if (Input.GetKey(KeyCode.A))
        {
            // Zmiana prêdkoœci w osi X, zachowuj¹c prêdkoœæ w osi Y
            rb.linearVelocity = new Vector2(-moveSpeed, rb.linearVelocity.y);
        }
        else
        {
            // Jeœli ¿aden klawisz nie jest wciœniêty, zatrzymaj ruch w poziomie
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }
    }
}
