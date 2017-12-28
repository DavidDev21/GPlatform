using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAI : MonoBehaviour {

    private GameObject theCamera;
    private GameObject gameFlow;

    private float cameraSize; // cameraSize represents the orthographicSize of the camera

    // Use this for initialization
    void Start () {
        theCamera = GameObject.FindGameObjectWithTag("MainCamera");
        gameFlow = GameObject.FindGameObjectWithTag("GameFlow");

        //Measured from the center of the camera to the edge (horizontally / vertically)
        cameraSize = theCamera.GetComponent<Camera>().orthographicSize;

        // Spawn Point
        transform.position = new Vector2(Random.Range(-FloorGeneration.groundLength, FloorGeneration.groundLength), Random.Range(10, 20));
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(transform.position.y < (theCamera.transform.position.y - cameraSize))
        {
            transform.position = new Vector2(Random.Range(-FloorGeneration.groundLength,FloorGeneration.groundLength), Random.Range(10, 20));
        }
	}

    void OnCollisionEnter2D(Collision2D otherObject)
    {
        if(otherObject.gameObject.tag == "RespawnTrigger")
        {
            transform.position = new Vector2(Random.Range(-FloorGeneration.groundLength, FloorGeneration.groundLength), Random.Range(10, 20));
            Destroy(otherObject.gameObject);
        }

        if(otherObject.gameObject.tag == "Player")
        {
            gameFlow.SendMessage("killPlayer");
        }
    }
}
