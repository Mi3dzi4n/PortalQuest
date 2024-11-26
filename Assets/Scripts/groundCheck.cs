using UnityEngine;

public class groundCheck : MonoBehaviour
{
    public Vector2 BoxSize;
    public float castDistance;
    public LayerMask groundLayer;
    public bool isGrounded()
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
}