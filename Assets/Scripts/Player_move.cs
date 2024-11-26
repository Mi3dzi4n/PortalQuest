using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public Vector2 BoxSize;
    public float castDistance;
    public LayerMask groundLayer;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    public bool isGrounded()
    {
        return Physics2D.BoxCast(transform.position, BoxSize, 0, -transform.up, castDistance, groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, BoxSize);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Sprawdzenie czy kolizja dotyczy obiektu na warstwie "groundLayer" (lub innej zgodnej z wymaganiami)
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            // Natychmiast wy³¹cz animacjê skoku
            animator.SetBool("IsJumping", false);
        }
    }
}