using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    double maxforce = 10;
    void Start()
    {
        Invoke("delete", 4);
    }

    // Update is called once per frame
    void Update()
    {
        maxforce = maxforce - 0.25 * Time.deltaTime;
        rb.velocity = new Vector2(3, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Damage"))
        {
            delete();
        }
    }
    void delete()
    {
        Destroy(gameObject);
    }
}
