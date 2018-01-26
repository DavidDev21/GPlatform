using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls the music of the game
// Author: David Zheng
// Tested: 12/28/2017
public class MusicController : MonoBehaviour {

    private AudioSource music1;
    private AudioSource music2;
    private AudioSource music3;
    private AudioSource currentSong;

    private AudioSource[] playlist = new AudioSource[3];

    private float currentSongLength;
    private float timer = 0f;

    // Creating a classless var to hold the current instance of the class
    private static MusicController instance;
    public static MusicController GetInstance()
    {
        return instance;
    }

    void Awake()
    {
        // This is the case when the new MusicController instance is created
        // instance refers to the first instance of this class (When the object was first created)
        // "this" in this current situation refers to the newly created instance, which must be destroyed
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject); // Removes overlapping instances of MusicController
            return;
        }
        else
        {
            instance = this; // The first instance will be "this"
        }
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start ()
    {
        music1 = GameObject.Find("Generic Music Loop 1").GetComponent<AudioSource>();
        music2 = GameObject.Find("Generic Music Loop 2").GetComponent<AudioSource>();
        music3 = GameObject.Find("Generic Music Loop 3").GetComponent<AudioSource>();

        playlist[0] = music1;
        playlist[1] = music2;
        playlist[2] = music3;

        currentSong = pickASong();
        currentSongLength = currentSong.clip.length;
        Debug.Log(currentSongLength);
    }
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log(timer);
	    if(timer > currentSongLength)
        {
            Debug.Log("I picked a new song");
            timer = 0;
            // pick a new song
            currentSong = pickASong();
            currentSongLength = currentSong.clip.length;
        }
        timer += Time.deltaTime;
	}

    // Pick a song from the playlist
    AudioSource pickASong()
    {
        int choice = Random.Range(0, 3);

        playlist[choice].Play();
        return playlist[choice];
    }

    // Returns the current song playing
    AudioSource getCurrentSong()
    {
        for(int i = 0; i < playlist.Length; ++i)
        {
            // If a song is playing
            if (playlist[i].isPlaying)
                return playlist[i];
        }

        // Should never be here
        return null;
    }
}
