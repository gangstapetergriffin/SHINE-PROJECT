using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public TMP_Text playerScoreText;
    int playerHealth = 1;
    int playerScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerScoreText.text = playerScore + " :";
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth <= 0)
        {
            SceneManager.LoadScene(0);
        }
        if(playerHealth <= 0) 
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
        if (collision.gameObject.CompareTag("Damage"))
        {
            playerHealth--;
            gameObject.transform.localScale = new Vector2(4, 4);
        }
        if (collision.gameObject.CompareTag("coin"))
        {
            playerScore++;
            playerScoreText.text = playerScore + " :";
        }
    }
}
