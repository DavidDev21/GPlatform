using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileStartAnimation : MonoBehaviour {

    private float cameraSize;
	// Use this for initialization
	void Start () {
        cameraSize = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().orthographicSize;
        transform.position = new Vector2(Random.Range(-cameraSize, cameraSize), Random.Range(10, 20));
    }
	
    // Respawn when collide with ground
    void OnCollisionEnter2D(Collision2D otherObject)
    {
        if (otherObject.gameObject.tag == "RespawnTrigger" || otherObject.gameObject.tag == "Wall")
        {
            transform.position = new Vector2(Random.Range(-cameraSize, cameraSize), Random.Range(10, 20));
        }
    }
}
