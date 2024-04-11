using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class enemy : MonoBehaviour
{
    private float speed = 2f;
    private bool movingRight = true;
    public Transform groundDetection;
    public GameObject PRefab;
    void Update()
    {
            transform.Translate(Vector2.right * -speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);
        if (groundInfo.collider == false)
        {
            if (movingRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0); // Flip the enemy to face left
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0); // Flip the enemy to face right
                movingRight = true;
            }
        }

        RaycastHit2D wallInfo = Physics2D.Raycast(groundDetection.position, movingRight ? Vector2.right : Vector2.left, 0f);
        if (wallInfo.collider == true)
        {
            if (wallInfo.collider.tag != "Player") {
                if (movingRight)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0); // Flip the enemy to face left
                    movingRight = false;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0); // Flip the enemy to face right
                    movingRight = true;
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Instantiate(PRefab, gameObject.transform.position, Quaternion.identity);
        }
        if (collision.gameObject.CompareTag("fireball"))
        {
            Destroy(gameObject);
            Instantiate(PRefab, gameObject.transform.position, Quaternion.identity);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("fireball"))
        {
            Destroy(gameObject);
            Instantiate(PRefab, gameObject.transform.position, Quaternion.identity);
        }
    }

}
