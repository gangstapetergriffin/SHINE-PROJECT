using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public TMP_Text playerScoreText;
    public TMP_Text Gamewontext;
    public TMP_Text gamewonscoretext;
    int playerHealth = 1;
    int playerScore = 0;
    bool powercherries = false;
    public GameObject prefab;
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
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
        if (powercherries)
        {
            if (Input.GetKeyDown (KeyCode.F)) 
            {
                //Instantiate(prefab, gameObject.transform.position, Quaternion.identity); needs fixing
            }
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
            powercherries = false;
            playerScore--;
            gameObject.transform.localScale = new Vector2(4, 4);
        }
        if (collision.gameObject.CompareTag("coin"))
        {
            playerScore++;
            playerScoreText.text = playerScore + " :";
        }
        if (collision.gameObject.CompareTag("cherries"))
        {
            powercherries = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("finish"))
        {
            Gamewontext.text = "you won the game";
            gamewonscoretext.text = "score: " + playerScore;
            Invoke("gamewon", 5);
        }
    }
    void gamewon()
    {
        SceneManager.LoadScene(0);
    }
}
