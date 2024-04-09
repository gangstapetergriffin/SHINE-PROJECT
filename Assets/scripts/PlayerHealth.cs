using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    int playerHealth = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Apple") && playerHealth < 2)
        {
            playerHealth++;
            gameObject.transform.localScale = new Vector2(3, 5);
        }
        if (collision.gameObject.CompareTag("DEATH"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
