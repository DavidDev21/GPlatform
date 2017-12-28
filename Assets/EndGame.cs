using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour {

    private GameObject thePlayer;
    private GameObject gameOverText;

    private float cameraSize;

    private Transform respawnPoint;

    // Use this for initialization
    void Start ()
    {
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        gameOverText = GameObject.Find("GameOver");

        gameOverText.SetActive(false);
        cameraSize = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().orthographicSize;

        respawnPoint = thePlayer.transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        killPlayer();
	}

    // Determines the player's death (falling off the camera's view)
    void killPlayer()
    {
        // Kill the player if it falls below the camera
        if (thePlayer.transform.position.y < (cameraSize * -1))
        {
            gameOverText.SetActive(true);
            transform.position = respawnPoint.position;
            Time.timeScale = 0;
        }
    }
}
