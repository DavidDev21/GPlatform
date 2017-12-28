using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    private float cameraOffset = 4f; // Offset from the player object

    private GameObject player;

	// Use this for initialization
	void Start (){
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// LateUpdate is called after Update()
	void LateUpdate () {
        cameraFollow(player);
    }

    // Camera will always center at the player (Let's see if this works nice)
    void cameraFollow(GameObject target)
    {
        Transform targetLocation = target.GetComponent<Transform>();
        Vector3 cameraTravel = new Vector3(targetLocation.position.x, transform.position.y, transform.position.z);

        // Adjusts the new camera location based on constraints
        if(targetLocation.position.x < minX)
            cameraTravel.x = minX;
        if (targetLocation.position.x > maxX)
            cameraTravel.x = maxX;
        if (targetLocation.position.y < minY)
            cameraTravel.y = minY;
        if (targetLocation.position.y > maxY)
            cameraTravel.y = maxY;

        transform.position = cameraTravel;
    }
}
