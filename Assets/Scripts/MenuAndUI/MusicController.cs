using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour {

	private AudioSource music;

	//destroys a music player when two load into the scene at the same time
	void Awake()
	{
		GameObject[] musicsources = GameObject.FindGameObjectsWithTag ("MusicPlayer");
		if (musicsources.Length > 1) 
		{
			Destroy (this.gameObject);
		}

		DontDestroyOnLoad (this.gameObject);
	}

	void Start () {
		music = GetComponent <AudioSource> ();
	}
	
	// changes the volume based on the player pref
	void Update () {
		music.volume = PlayerPrefs.GetFloat ("volume");
	}
}
