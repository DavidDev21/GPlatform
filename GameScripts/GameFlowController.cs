using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Manges the flow of the game (From Death to Respawn)
// Author: David Zheng
// Written on: 12/28/2017

public class GameFlowController : MonoBehaviour {
    public Text timerText;
    public Text score;
    public Text gameOverText;

    private GameObject thePlayer;

    private float cameraSize;
    private float timer = 0;

    private bool playerDead = false;

    // Use this for initialization
    void Start()
    {
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        cameraSize = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().orthographicSize;

        gameOverText.enabled = false;
        score.enabled = false;
        timerText.enabled = true;

        for(int i = 1; i < 5; ++i)
        {
            Instantiate(GameObject.FindGameObjectWithTag("Projectile"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (thePlayer.transform.position.y < (cameraSize * -1))
        {
            killPlayer();
        }
        timerText.text = "Timer: " + timer.ToString("f2");
        timer += Time.deltaTime;
    }

    // the check for restartGame() must be after Update() determines whether the player is dead
    // Not during (Caused some bug, where the game wouldn't let the game resume after player restarts)
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.R) && playerDead)
        {
            restartGame();
        }
    }

    // Kill off the player and pause the game
    void killPlayer()
    {
            gameOverText.enabled = true;
            Time.timeScale = 0;
            playerDead = true;
            displayScore();
    }
    
    // Display final score (Based off how long you survived)
    void displayScore()
    {
        score.text = "Score: " + timer.ToString("f2");
        score.enabled = true;
        timerText.enabled = false;
    }

    // Restarts the game
    void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        playerDead = false;
        Time.timeScale = 1;
    }
}
