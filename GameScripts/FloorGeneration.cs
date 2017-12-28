using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Generates the destructable floor, relative to the camera position, which is made up of 1 by 1 blocks
// Author: David Zheng
// Tested: 12/27/2017

public class FloorGeneration : MonoBehaviour
{
    private GameObject theGround;
    private GameObject theCamera;
    private GameObject clone;

    private float horizontalOffset;
    private float numBlockAway = 1f; // # of blocks away from initial block
    public static float groundLength; // The length of the ground, from the center anchor point of the camera (x-component)
    // groundEndpts is also used in ProjectileAI for respawn point calculation. Thus it must be static

    // Use this for initialization
    void Start()
    {
        // Setup
        theGround = GameObject.FindGameObjectWithTag("RespawnTrigger");
        theCamera = GameObject.FindGameObjectWithTag("MainCamera");

        // The length of the ground
        groundLength = (theCamera.GetComponent<Camera>().orthographicSize * 2) + 3;

        // the offset on the x-axis for the next block
        horizontalOffset = theGround.transform.localScale.x;

        // Make sure the initial first ground block is at the correct spot relative to the camera at start
        theGround.transform.position = new Vector2((theCamera.transform.position.x - groundLength), (theCamera.transform.position.y - 5));
      
        // Next Block Coordinate calculation
        Vector2 nextBlockLoc = new Vector2(theGround.transform.position.x + (horizontalOffset * numBlockAway), theGround.transform.position.y);

        // Note: the 2nd parameter of Instantiate determines the parent of the clone as well.
        clone = Instantiate(theGround,transform);
        clone.transform.position = nextBlockLoc;
        
        // Generates the rest of the blocks until reaches the full intended length of the ground
        while (nextBlockLoc.x < theCamera.transform.position.x + groundLength)
        {
            ++numBlockAway;
            nextBlockLoc = new Vector2(theGround.transform.position.x + (horizontalOffset * numBlockAway), theGround.transform.position.y);
            clone = Instantiate(theGround,transform);
            clone.transform.position = nextBlockLoc;
        }
   
    }
}
