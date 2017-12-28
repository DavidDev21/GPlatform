using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	private float playerSpeed = 20f;
    private float jumpPower = 450f;

    private bool isFacingRight = true;
    private bool doubleJumpEnable = true;
    private bool touchingGround = false; // Not initally

	// Update is called once per frame
	void Update ()
    {
        movePlayer();
    }

    // Player Controls
    void movePlayer()
    {
        // gameObject refers to the Player gameObject (Should only be used on the Player)
        float moveX = Input.GetAxis("Horizontal");

        // Jump control
        if (Input.GetButtonDown("Jump"))
        {
            jumpPlayer();
        }
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

        // Applying calculation results
        Rigidbody2D playerRB = gameObject.GetComponent<Rigidbody2D>();
        playerRB.velocity = new Vector2((moveX * playerSpeed), playerRB.velocity.y);
    }


	// jump Player
	void jumpPlayer()
	{
        if(touchingGround || (!touchingGround && doubleJumpEnable))
        {
            if (!touchingGround)
                doubleJumpEnable = false;
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPower);
        }
        touchingGround = false;
	}

    // Enables doubleJump if touching the ground again
    void OnCollisionEnter2D(Collision2D otherObject)
    {
        if(otherObject.gameObject.tag == "RespawnTrigger")
        {
            doubleJumpEnable = true;
            touchingGround = true;
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
