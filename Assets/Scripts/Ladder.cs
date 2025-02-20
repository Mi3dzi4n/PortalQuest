using UnityEngine;
using UnityEngine.Tilemaps;

public class Ladder : MonoBehaviour
{
    private float vertical;
    private float speed = 8f;
    private bool IsLadder;
    private bool IsClimbing;
    public Animator animator;


    [SerializeField] private Rigidbody2D rb;
    private void Start()
    {
        animator = GetComponent<Animator>();

    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");

        if (IsLadder && Mathf.Abs(vertical) > 0f)
        {
            IsClimbing = true;
        }
    }

    private void FixedUpdate()
    {
        if (IsClimbing)
        {
            animator.SetBool("IsJumping", false);
            rb.gravityScale = 0f;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, vertical * speed);
        }
        else
        {
            rb.gravityScale = 4f;
        }
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
            IsClimbing = false;
        }
    }
}
