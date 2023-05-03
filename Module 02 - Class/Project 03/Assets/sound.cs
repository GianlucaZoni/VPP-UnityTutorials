using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour {

	public AudioSource ballSound;

	// Use this for initialization
	void Start () {

		ballSound = GetComponent<AudioSource>();
		
	}
	
	// Update is called once per frame
	void OnMouseDown () {
    ballSound.Play ();
		
	}
}
