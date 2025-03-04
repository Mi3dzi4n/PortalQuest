using System.Runtime.CompilerServices;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    public GameObject punktA;
    public GameObject punktB;
    private Rigidbody2D rb;
    private Transform CurrentPoint;
    private Animator animator;
    public float speed;
    public Vector2 BoxSize;
    public float castDistance;
    public Vector2 BoxSize2;
    public float castDistance2;
    public float offsetX = 0f;  // Przesuniêcie po osi X dla pierwszego boxa
    public float offsetX2 = 0f; // Przesuniêcie po osi X dla drugiego boxa
    public LayerMask groundLayer;
    public float jumpHeight;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetBool("IsRunning", true);
        CurrentPoint = punktB.transform;
    }


    void Update()
    {
        Vector2 point = CurrentPoint.position - transform.position;
        if (CurrentPoint == punktB.transform)
        {
            rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = new Vector2(-speed, rb.linearVelocity.y);
        }
        if (Vector2.Distance(transform.position, CurrentPoint.position) < 1f && CurrentPoint == punktB.transform)
        {
            Flip();
            CurrentPoint = punktA.transform;
        }
        if (Vector2.Distance(transform.position, CurrentPoint.position) < 1f && CurrentPoint == punktA.transform)
        {
            Flip();
            CurrentPoint = punktB.transform;
        }
        if (Physics2D.BoxCast(transform.position + Vector3.right * offsetX, BoxSize, 0, -transform.up, castDistance, groundLayer))
        {
            
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpHeight);
        }
        if (Physics2D.BoxCast(transform.position + Vector3.right * offsetX2, BoxSize2, 0, -transform.up, castDistance2, groundLayer))
        {
            
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpHeight);
        }

    }
    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(punktA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(punktB.transform.position, 0.5f);
        Gizmos.DrawLine(punktA.transform.position, punktB.transform.position);
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance + Vector3.right * offsetX, BoxSize);
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance2 + Vector3.right * offsetX2, BoxSize2);
    }

}
