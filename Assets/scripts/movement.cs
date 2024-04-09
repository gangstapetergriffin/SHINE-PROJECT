using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class movement : MonoBehaviour
{
    private float horizontal;
    private float speed = 4f;
    private float jumpingPower = 16.5f;
    private bool isFacingRight = true;
    public AnimatorController[] animationarray;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator animator;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetButton("Horizontal") && IsGrounded())
        {
            animator.runtimeAnimatorController = animationarray[1];
        } else if (IsGrounded())
        {
            animator.runtimeAnimatorController = animationarray[0];
        }


        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

        }

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
