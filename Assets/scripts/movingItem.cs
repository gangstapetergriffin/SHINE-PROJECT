using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingItem : MonoBehaviour
{
    public Rigidbody2D rb;
    int yessking = 1;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        yessking = Random.Range(0, 2);
        rb.velocity = new Vector2 (10, rb.velocity.x);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (yessking == 0 && IsGrounded())
        {
            rb.velocity = new Vector2(-3, rb.velocity.y);
        }
        else if (IsGrounded())
        {
            rb.velocity = new Vector2(3, rb.velocity.y);
        }
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        Destroy(gameObject);
    }

}
