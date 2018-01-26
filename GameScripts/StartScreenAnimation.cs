using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenAnimation : MonoBehaviour {

    private float jumpPower = 450f;

    private bool isFacingRight = true;
    Rigidbody2D playerRB;
    void Start()
    {
        // Applying calculation results for the player object
        playerRB = gameObject.GetComponent<Rigidbody2D>();
        playerRB.velocity = new Vector2(300, playerRB.velocity.y);

        // Spawn projectiles
        for(int i = 1; i < 8; ++i)
        {
            Instantiate(GameObject.FindGameObjectWithTag("Projectile"));
        }
    }
    // Update is called once per frame
    void Update ()
    {
        if(playerRB.velocity.x == 0)
        {
            playerRB.velocity = new Vector2(Random.Range(-100,100), playerRB.velocity.y);
        }

        // Start the game if user presses any key
        if(Input.anyKey)
        {
            SceneManager.LoadScene(1);
        }
    }

    // Bounce the player around randomly
    void OnCollisionEnter2D(Collision2D otherObject)
    {
        if(otherObject.gameObject.tag == "RespawnTrigger")
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPower);
        }
        if(otherObject.gameObject.tag == "Wall")
        {
            // gameObject refers to the Player gameObject (Should only be used on the Player)
            float moveX = Random.Range(-300, 300);

            // Moving Left, but not facing Left
            if (moveX < 0f && isFacingRight)
            {
                flipPlayer();
            }
            // Moving Right, but not facing right
            else if (moveX > 0f && !isFacingRight)
            {
                flipPlayer();
            }
            playerRB.velocity = new Vector2(moveX, playerRB.velocity.y);
        }
    }

    // Flips the Orientation of the player, by negating the scale on the x-axis
    void flipPlayer()
    {
        isFacingRight = !isFacingRight;
        Vector2 newScale = gameObject.transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }
}
