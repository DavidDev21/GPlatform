using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Manges the flow of the game (From Death to Respawn)
// Author: David Zheng
// Written on: 12/28/2017

public class GameFlowController : MonoBehaviour {

    private GameObject thePlayer;
    private GameObject gameOverText;

    private float cameraSize;

    private Transform respawnPoint;

    private bool playerDead = false;

    // Use this for initialization
    void Start()
    {
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        gameOverText = GameObject.Find("GameOver");

        gameOverText.SetActive(false);
        cameraSize = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().orthographicSize;

        respawnPoint = thePlayer.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey && playerDead)
        {
            Debug.Log("I have restarted");
            restartGame();

            Debug.Log(Time.timeScale);
        }

        // Kill the player if player falls below the camera
        if(thePlayer.transform.position.y < (cameraSize * -1))
        {
            killPlayer();
        }
    }

    // Kills the player
    public void killPlayer()
    {
        gameOverText.SetActive(true);
        transform.position = respawnPoint.position;
        Time.timeScale = 0;
        playerDead = true;
    }

    // Restarts the game
    void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        playerDead = false;
        Time.timeScale = 1;
    }
}
